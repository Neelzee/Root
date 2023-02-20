using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using static WorldParameters;
using Random = UnityEngine.Random;

public class WorldTiles : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private Tile[] lowGrassTiles;
    [SerializeField] private Tile[] medGrassTiles;
    [SerializeField] private Tile[] highGrassTiles;
    [SerializeField] private Tile[] lowSavannaTiles;
    [SerializeField] private Tile[] medSavannaTiles;
    [SerializeField] private Tile[] highSavannaTiles;
    [SerializeField] private Tile[] lowJungleTiles;
    [SerializeField] private Tile[] medJungleTiles;
    [SerializeField] private Tile[] highJungleTiles;
    [SerializeField] private Tile[] lowMountainTiles;
    [SerializeField] private Tile[] medMountainTiles;
    [SerializeField] private Tile[] highMountainTiles;
    [SerializeField] private Tile[] lowSnowTiles;
    [SerializeField] private Tile[] medSnowTiles;
    [SerializeField] private Tile[] highSnowTiles;
    [SerializeField] private Tile[] mLowSnowTiles;
    [SerializeField] private Tile[] mMedSnowTiles;
    [SerializeField] private Tile[] mHighSnowTiles;
    [SerializeField] private Tile[] lakeTiles;
    [SerializeField] private Tile[] lowDesertTiles;
    [SerializeField] private Tile[] medDesertTiles;
    [SerializeField] private Tile[] highDesertTiles;
    [SerializeField] private Tile[] debugTiles;


    [Header("Tile Maps")]
    [SerializeField] private Tilemap lake;
    [SerializeField] private Tilemap low;
    [SerializeField] private Tilemap med;
    [SerializeField] private Tilemap high;
    [SerializeField] private Tilemap river;
    [SerializeField] private Tilemap lowDesert;
    [SerializeField] private Tilemap medDesert;
    [SerializeField] private Tilemap highDesert;
    [SerializeField] private Tilemap lowMountain;
    [SerializeField] private Tilemap medMountain;
    [SerializeField] private Tilemap highMountain;
    [SerializeField] private Tilemap lowSnow;
    [SerializeField] private Tilemap medSnow;
    [SerializeField] private Tilemap highSnow;
    [SerializeField] private Tilemap mLowSnow;
    [SerializeField] private Tilemap mMedSnow;
    [SerializeField] private Tilemap mHighSnow;

    public Tile[] LakeTiles => lakeTiles;


    public Tile[] LowMountainTiles => lowMountainTiles;

    public Tile[] MedMountainTiles => medMountainTiles;

    public Tile[] HighMountainTiles => highMountainTiles;

    public Tile[] LowSnowTiles => lowSnowTiles;

    public Tile[] MedSnowTiles => medSnowTiles;

    public Tile[] HighSnowTiles => highSnowTiles;

    public Tile[] MLowSnowTiles => mLowSnowTiles;

    public Tile[] MMedSnowTiles => mMedSnowTiles;

    public Tile[] MHighSnowTiles => mHighSnowTiles;

    public Tile[] LowDesertTiles => lowDesertTiles;

    public Tile[] MedDesertTiles => medDesertTiles;

    public Tile[] HighDesertTiles => highDesertTiles;

    public Tilemap Lake => lake;

    public Tilemap Low => low;

    public Tilemap Med => med;

    public Tilemap High => high;

    public Tilemap LowMountain => lowMountain;

    public Tilemap MedMountain => medMountain;

    public Tilemap HighMountain => highMountain;

    public Tilemap LowSnow => lowSnow;

    public Tilemap MedSnow => medSnow;

    public Tilemap HighSnow => highSnow;

    public Tilemap MLowSnow => mLowSnow;

    public Tilemap MMedSnow => mMedSnow;

    public Tilemap MHighSnow => mHighSnow;

    public Tilemap River => river;
    
    private const float Third = .3f;
    private const float TwoThirds = .6f;

    private static WorldTiles _instance;
    
    public static WorldTiles Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }
    
    /// <summary>
    /// Returns the correct tile and tilemap that corresponds to the given height value
    /// </summary>
    /// <param name="heightVal"></param>
    /// <returns></returns>
    public (Tilemap, Tile) GetRandomMountainTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;

        return heightVal switch
        {
            7 => (medMountain,
                plainTile ? medMountainTiles[0] : medMountainTiles[Random.Range(0, medMountainTiles.Length)]),
            8 => (highMountain,
                plainTile ? highMountainTiles[0] : highMountainTiles[Random.Range(0, highMountainTiles.Length)]),
            _ => (lowMountain,
                plainTile ? lowMountainTiles[0] : lowMountainTiles[Random.Range(0, lowMountainTiles.Length)])
        };
    }


    public (Tilemap, Tile) GetRandomSnowTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        
        return heightVal switch
        {
            4 => (medSnow, plainTile ? medSnowTiles[0] : medSnowTiles[Random.Range(0, medSnowTiles.Length)]),
            5 => (highSnow, plainTile ? highSnowTiles[0] : highSnowTiles[Random.Range(0, highSnowTiles.Length)]),
            6 => (mLowSnow, plainTile ? mLowSnowTiles[0] : mLowSnowTiles[Random.Range(0, mLowSnowTiles.Length)]),
            7 => (mMedSnow, plainTile ? mMedSnowTiles[0] : mMedSnowTiles[Random.Range(0, mMedSnowTiles.Length)]),
            8 => (mHighSnow, plainTile ? mHighSnowTiles[0] : mHighSnowTiles[Random.Range(0, mHighSnowTiles.Length)]),
            _ => (lowSnow, plainTile ? lowSnowTiles[0] : lowSnowTiles[Random.Range(0, lowSnowTiles.Length)])
        };
    
    }

    public (Tilemap, Tile) GetRandomDesertTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;

        return heightVal switch
        {
            4 => (medDesert, plainTile ? medDesertTiles[0] : medDesertTiles[Random.Range(0, medDesertTiles.Length)]),
            5 => (highDesert, plainTile ? highDesertTiles[0] : highDesertTiles[Random.Range(0, highDesertTiles.Length)]),
            _ => (lowDesert, plainTile ? lowDesertTiles[0] : lowDesertTiles[Random.Range(0, lowDesertTiles.Length)])
        };
    }

    public (Tilemap, Tile) GetRandomSavannaTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        
        return heightVal switch
        {
            4 => (med, plainTile ? medSavannaTiles[0] : medSavannaTiles[Random.Range(0, medSavannaTiles.Length)]),
            5 => (high, plainTile ? highSavannaTiles[0] : highSavannaTiles[Random.Range(0, highSavannaTiles.Length)]),
            _ => (low, plainTile ? lowSavannaTiles[0] : lowSavannaTiles[Random.Range(0, lowSavannaTiles.Length)])
        };
    }
    
    public (Tilemap, Tile) GetRandomJungleTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;

        return heightVal switch
        {
            4 => (med, plainTile ? medJungleTiles[0] : medJungleTiles[Random.Range(0, medJungleTiles.Length)]),
            5 => (high, plainTile ? highJungleTiles[0] : highJungleTiles[Random.Range(0, highJungleTiles.Length)]),
            _ => (low, plainTile ? lowJungleTiles[0] : lowJungleTiles[Random.Range(0, lowJungleTiles.Length)])
        };
    }
    
    public (Tilemap, Tile) GetRandomGrasslandTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        
        return heightVal switch
        {
            4 => (med, plainTile ? medGrassTiles[0] : medGrassTiles[Random.Range(0, medGrassTiles.Length)]),
            5 => (high, plainTile ? highGrassTiles[0] : highGrassTiles[Random.Range(0, highGrassTiles.Length)]),
            _ => (low, plainTile ? lowGrassTiles[0] : lowGrassTiles[Random.Range(0, lowGrassTiles.Length)])
        };
    }

    public Tile DebugTile(int val)
    {
        val = val < 0 ? 0 : val >= debugTiles.Length ? debugTiles.Length - 1 : val;

        return debugTiles[val];
    }
}
