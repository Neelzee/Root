using System;
using UnityEngine;
using UnityEngine.Tilemaps;

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
    /// <summary>
    /// Returns an array of the surrounding biomes values, first element is moistness, second is temperature.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException">If the given point is out of range</exception>
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

    /// <summary>
    /// Calculates the euclidean distance between a given point and the closet lake tile
    /// TODO: Improve this function with a better algorithm
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="maxDistToCheck">How far away too check for lake</param>
    /// <returns></returns>
    /// <exception cref="MissingComponentException">If the tilemap component cannot be found</exception>
    public static float DistanceToClosestLake(Vector3Int pos, float maxDistToCheck = 100f)
    {
        Tilemap tm = null;
        var obj = GameObject.FindGameObjectWithTag("Grid");
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == "Lake")
            {
                tm = obj.transform.GetChild(i).GetComponent<Tilemap>();
            }
        }

        if (tm == null)
        {
            throw new MissingComponentException("Cant find Lake Tilemap");
        }

        float minDist = float.MaxValue;
        for (float x = pos.x - maxDistToCheck; x < pos.x + maxDistToCheck + 1; x++)
        {
            for (float y = pos.y - maxDistToCheck; y < pos.y + maxDistToCheck + 1; y++)
            {
                var p = new Vector3Int((int)x, (int)y, 0);
                if (tm.GetTile<Tile>(p) != null)
                {
                    float dist = Vector3Int.Distance(pos, p);
                    if (dist >= minDist)
                    {
                        continue;
                    }

                    minDist = dist;
                }
            }
        }

        return minDist;
    }
}
