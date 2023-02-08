using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldTiler : MonoBehaviour
{
    public void Tile()
    {
        if (!World.Initialised)
        {
            return;
        }

        var heightMap = World.HeightMap;
        var moistMap = World.MoistnessMap;
        var tempMap = World.TempMap;

        for (int x = 0; x < heightMap.GetLength(0); x++)
        {
            for (int y = 0; y < heightMap.GetLength(1); y++)
            {
                var heightVal = heightMap[x, y];
                var moistVal = moistMap[x, y];
                var tempVal = tempMap[x, y];

                var p = new Vector3Int(x, y, 0);


                var (tm, tile) = WorldTiles.Instance.GetRandomGrasslandTile(heightVal);
                if (heightVal <= World.MinHeight + WorldParameters.Instance.LakeHeight)
                {
                    tm = WorldTiles.Instance.Lake;
                    int v = heightVal >= WorldTiles.Instance.LakeTiles.Length
                        ? WorldTiles.Instance.LakeTiles.Length - 1
                        : heightVal < 0 ? 0 : heightVal;
                    tile = WorldTiles.Instance.LakeTiles[v];
                }
                else if (heightVal >= World.MaxHeight - WorldParameters.Instance.MountainHeight)
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomMountainTile(heightVal);
                }
                else if (tempVal > 1) // Hot
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomDesertTile(heightVal);
                }
                else if (tempVal < 1) // Cold
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomSnowTile(heightVal);
                }
                else if (moistVal < 1) // Dry
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomSavannaTile(heightVal);
                }
                else if (moistVal > 1) // Moist
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomJungleTile(heightVal);
                } 
                
                tm.SetTile(p, tile);
            }
        }
    }
}
