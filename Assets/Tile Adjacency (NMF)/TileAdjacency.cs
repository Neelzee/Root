using System;
using UnityEngine;

/// <summary>
/// Returns the tile adjacency for a specific position
/// <para>
/// <c>
/// Author: Nils Michael Fitjar
/// </c>
/// </para>
/// </summary>
public static class TileAdjacency
{
    public static (int, int)[,] GetAdjacencyValues(Vector3Int pos, int radius = 1)
    {
        if (pos.x < 0 || pos.y < 0 || pos.x >= World.MoistnessMap.GetLength(0) ||
            pos.y >= World.MoistnessMap.GetLength(1))
        {
            throw new IndexOutOfRangeException(
                "Given tile position: " + pos
                                        + " is out of range of the expected Tilemap, value range expected X: 0 "
                + World.MoistnessMap.GetLength(0) + " and Y: " + World.MoistnessMap.GetLength(0));
        }

        var arr = new (int, int)[radius + 1, radius + 1];
        
        for (int x = pos.x - radius; x < pos.x + radius + 1; x++)
        {
            for (int y = pos.y - radius; y < pos.y + radius + 1; y++)
            {
                arr[x, y] = (World.MoistnessMap[x, y], World.TempMap[x, y]);
            }
        }

        return arr;
    }
}
