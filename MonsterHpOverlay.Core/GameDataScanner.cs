using MonsterHpOverlay.Core.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameDataScanner
{
    private readonly static List<GameData> _gameDataList = new List<GameData>();

    public static void Start()
    {
        Thread scanThread = new Thread(() =>
        {
            do
            {
                Scan();
                Thread.Sleep(50);
            } while (true);
        });
        scanThread.Start();
    }

    public static void Scan()
    {
        var scanTask = new List<Task>();
        foreach(var gameData in _gameDataList)
        {
            scanTask.Add(Task.Run(gameData.ScanData));
        }

        Task.WaitAll(scanTask.ToArray());
    }

    public static void Add(GameData gameData)
    {
        lock (_gameDataList)
        {
            if (!_gameDataList.Contains(gameData))
            {
                _gameDataList.Add(gameData);
            }
        }
    }

    public static void Remove(GameData gameData)
    {
        lock (_gameDataList)
        {
            if (_gameDataList.Contains(gameData))
            {
                _gameDataList.Remove(gameData);
            }
        }
    }
}