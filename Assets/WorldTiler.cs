using System.Collections;
using System.Collections.Generic;
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
                
                // Checks height, if low, its river/lake
                if (heightVal <= WorldParameters.Instance.RiverHeight)
                {
                    tm = WorldTiles.Instance.River;
                    tile = WorldTiles.Instance.LakeTiles[heightVal];
                }
                else if (heightVal >= WorldParameters.Instance.MountainHeight) // If high, its mountain
                {
                    (tm, tile) = WorldTiles.Instance.GetRandomMountainTile(heightVal);
                } 
                else
                    (tm, tile) = tempVal switch
                    {
                        < 1 =>
                            // Checks moisture and temp
                            // If temp is low, its snow, no matter what
                            WorldTiles.Instance.GetRandomSnowTile(heightVal),
                        // If temp is high, its desert, unless its at mountain height
                        > 1 when heightVal < WorldParameters.Instance.MountainHeight => WorldTiles.Instance
                            .GetRandomDesertTile(heightVal),
                        _ => moistVal switch
                        {
                            < 1 => WorldTiles.Instance.GetRandomSavannaTile(heightVal),
                            // High moisture, jungle time
                            > 1 => WorldTiles.Instance.GetRandomJungleTile(heightVal),
                            _ => (tm, tile)
                        }
                    };

                // Else is grassland
                // Places tiles
                tm.SetTile(p, tile);
            }
        }
    }
}
