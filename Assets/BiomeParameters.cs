using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeParameters : MonoBehaviour
{
    private Dictionary<(TileValue, TileValue), TileType> _biomesDict;

    public Dictionary<(TileValue, TileValue), TileType> BiomesDict => _biomesDict;

    private void Awake()
    {
        // Temp, Moisture
        _biomesDict.Add((TileValue.Low, TileValue.Low), TileType.Snow);
        _biomesDict.Add((TileValue.Low, TileValue.Medium), TileType.Snow);
        _biomesDict.Add((TileValue.Low, TileValue.High), TileType.Snow);
        _biomesDict.Add((TileValue.Medium, TileValue.Low), TileType.Savanna);
        _biomesDict.Add((TileValue.Medium, TileValue.Medium), TileType.Grasslands);
        _biomesDict.Add((TileValue.Medium, TileValue.High), TileType.Jungle);
        _biomesDict.Add((TileValue.High, TileValue.Low), TileType.Desert);
        _biomesDict.Add((TileValue.High, TileValue.Medium), TileType.Savanna);
        _biomesDict.Add((TileValue.High, TileValue.High), TileType.Jungle);
    }
}
