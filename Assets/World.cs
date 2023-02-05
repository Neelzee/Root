using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class World
{
    private static bool _initialised;

    public static bool Initialised
    {
        get => _initialised;
        set => _initialised = value;
    }

    private static int[,] _moistnessMap;

    public static int[,] MoistnessMap
    {
        get => _moistnessMap;
        set => _moistnessMap = value;
    }
    
    private static int[,] _heightMap;

    public static int[,] HeightMap
    {
        get => _heightMap;
        set => _heightMap = value;
    }
    
    private static int[,] _tempMap;

    public static int[,] TempMap
    {
        get => _tempMap;
        set => _tempMap = value;
    }

    public static List<Vector2Int> GetLocalMaxima(int[,] map)
    {
        var points = new List<Vector2Int>();
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                var noiseVal = map[x, y];
                if (CheckNeighbours(map, x, y, neighbourNoise => neighbourNoise > noiseVal))
                {
                    points.Add(new Vector2Int(x, y));
                }

            }
        }
        return points;
    }
    
    public static List<Vector2Int> GetLocalMinima(int[,] map)
    {
        var points = new List<Vector2Int>();
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                var noiseVal = map[x, y];
                if (CheckNeighbours(map, x, y, neighbourNoise => neighbourNoise < noiseVal))
                {
                    points.Add(new Vector2Int(x, y));
                }

            }
        }
        return points;
    }

    private static bool CheckNeighbours(int[,] map, int x, int y, Func<float, bool> failCon, int r = 1)
    {
        for (int i = x - r - 1; i < x + r + 1; i++)
        {
            for (int j = y - r - 1; j < y + r + 1; j++)
            {
                if (i < 0 || i >= map.GetLength(0) || j < 0 || j >= map.GetLength(1))
                {
                    continue;
                }

                if (failCon(map[i, j]))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
