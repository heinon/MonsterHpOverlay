using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Memory
{
    private readonly ArrayPool<byte> _bufferPool = ArrayPool<byte>.Shared;

    public static IntPtr ProcessHandle { get; private set; } = (IntPtr)0;

    public Memory(IntPtr handle)
    {
        ProcessHandle = handle;
    }

    public T Read<T>(long address) where T : struct
    {
        int lpByteCount = Marshal.SizeOf<T>() * (int)1;
        var buffer = new T[1];
        MemoryReader.ReadProcessMemory(ProcessHandle, (IntPtr)address, buffer, lpByteCount, out _);
        return buffer[0];
    }

    public T[] Read<T>(long address, uint count) where T : struct
    {
        int lpByteCount = Marshal.SizeOf<T>() * (int)count;
        var buffer = new T[count];
        MemoryReader.ReadProcessMemory(ProcessHandle, (IntPtr)address, buffer, lpByteCount, out _);
        return buffer;
    }

    public long Read(long baseAddress, int[] offsets)
    {
        long address = baseAddress;
        foreach (int offset in offsets)
        {
            long temp = Read<long>(address);

            // In case we get ptr to a null value
            if (temp == 0)
            {
                return 0;
            }

            address = temp + offset;
        }

        return address;
    }
}