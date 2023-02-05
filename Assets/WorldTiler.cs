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
                
                // Checks height, if low, its river/lake
                if (heightVal <= WorldParameters.Instance.RiverHeight)
                {
                    WorldTiles.Instance.River.SetTile(p, WorldTiles.Instance.LakeTiles[heightVal]);
                    continue;
                }

                // If high, its mountain
                if (heightVal >= WorldParameters.Instance.MountainHeight)
                {
                    WorldTiles.Instance.Mountain.SetTile(p, WorldTiles.Instance.GetRandomMountainTile(heightVal));
                    continue;
                }

                // Checks moisture and temp
                // If temp is low, its snow, no matter what
                if (tempVal < 1)
                {
                    WorldTiles.Instance.Snow.SetTile(p, WorldTiles.Instance.GetRandomSnowTile(heightVal));
                    continue;
                }
                
                // If temp is high, its desert, unless its at mountain height
                if (tempVal > 1 && heightVal < WorldParameters.Instance.MountainHeight)
                {
                    WorldTiles.Instance.Desert.SetTile(p, WorldTiles.Instance.GetRandomDesertTile(heightVal));
                    continue;
                }
                
                // Now we only need to check extreme dryness and moistness
                // Low moisture, savanna time :)
                if (moistVal < 1)
                {
                    WorldTiles.Instance.Dry.SetTile(p, WorldTiles.Instance.GetRandomSavannaTile(heightVal));
                    continue;
                }
                
                // High moisture, jungle time
                if (moistVal > 1)
                {
                    WorldTiles.Instance.Moist.SetTile(p, WorldTiles.Instance.GetRandomJungleTile(heightVal));
                    continue;
                }
                
                // Else is grassland
                WorldTiles.Instance.Damp.SetTile(p, WorldTiles.Instance.GetRandomGrasslandTile(heightVal));
            }
        }
    }
}
