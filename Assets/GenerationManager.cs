using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerationManager : MonoBehaviour
{
    [Header("Generate On Start")]
    [SerializeField] private bool generateOnStart;
    [SerializeField] private bool debugHeight;
    [SerializeField] private bool debugTemp;
    [SerializeField] private bool debugMoisture;

    private void Start()
    {
        if (!generateOnStart)
        {
            return;
        }

        var tGenerator = GetComponentInChildren<TerrainGeneration>();
        tGenerator.Generate();

        if (debugHeight)
        {
            var grid = GameObject.FindWithTag("Grid");
            var obj = Instantiate(grid.transform.GetChild(0).gameObject, grid.transform);
            obj.name = "Debug Height";
            var tm = obj.GetComponent<Tilemap>();
            tm.ClearAllTiles();
            var hm = World.HeightMap;

            for (int x = 0; x < hm.GetLength(0); x++)
            {
                for (int y = 0; y < hm.GetLength(1); y++)
                {
                    var p = new Vector3Int(x, y, 0);
                    
                    tm.SetTile(p, WorldTiles.Instance.DebugTile(hm[x, y]));
                }
            }

        }

        if (debugHeight || debugMoisture || debugTemp)
        {
            return;
        }
        
        var tiler = GetComponentInChildren<WorldTiler>();
        
        tiler.Tile();
    }
}
