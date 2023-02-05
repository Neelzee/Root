using System;
using System.Collections;
using System.Collections.Generic;
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
    [FormerlySerializedAs("riverTiles")] [SerializeField] private Tile[] lakeTiles;
    [SerializeField] private Tile[] lowDesertTiles;
    [SerializeField] private Tile[] medDesertTiles;
    [SerializeField] private Tile[] highDesertTiles;


    [Header("Tile Maps")]
    [SerializeField] private Tilemap dry;
    [SerializeField] private Tilemap damp;
    [SerializeField] private Tilemap moist;
    [SerializeField] private Tilemap river;
    [SerializeField] private Tilemap mountain;
    [SerializeField] private Tilemap snow;
    [SerializeField] private Tilemap desert;

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

    public Tilemap Dry => dry;

    public Tilemap Damp => damp;

    public Tilemap Moist => moist;

    public Tilemap Desert => desert;

    public Tilemap River => river;

    public Tilemap Mountain => mountain;

    public Tilemap Snow => snow;


    private static WorldTiles _instance;
    
    public static WorldTiles Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public Tile GetRandomMountainTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        
        int max = WorldParameters.Instance.HeightMax; 
        if (max / (float) heightVal <= .3f)
        {
            return plainTile ? lowMountainTiles[0] : lowMountainTiles[Random.Range(0, lowMountainTiles.Length)];
        }

        if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
        {
            return plainTile ? medMountainTiles[0] : medMountainTiles[Random.Range(0, medMountainTiles.Length)];
        }
        
        return plainTile ? highMountainTiles[0] : highMountainTiles[Random.Range(0, highMountainTiles.Length)];
    }


    public Tile GetRandomSnowTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        
        if (heightVal >= WorldParameters.Instance.MountainHeight)
        {
            int max = WorldParameters.Instance.HeightMax;
            if (max / (float) heightVal <= .3f)
            {
                return plainTile ? mLowSnowTiles[0] : mLowSnowTiles[Random.Range(0, mLowSnowTiles.Length)];
            }

            if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
            {
                return plainTile ? mMedSnowTiles[0] : mMedSnowTiles[Random.Range(0, mMedSnowTiles.Length)];
            }
    
            return plainTile ? mHighSnowTiles[0] : mHighSnowTiles[Random.Range(0, mHighSnowTiles.Length)];
        }

        {
            int max = WorldParameters.Instance.MountainHeight - 1;
            if (max / (float) heightVal <= .3f)
            {
                return plainTile ? lowSnowTiles[0] : lowSnowTiles[Random.Range(0, lowSnowTiles.Length)];
            }

            if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
            {
                return plainTile ? medSnowTiles[0] : medSnowTiles[Random.Range(0, medSnowTiles.Length)];
            }
        
            return plainTile ? highSnowTiles[0] : highSnowTiles[Random.Range(0, highSnowTiles.Length)];
        }
    }

    public TileBase GetRandomDesertTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        int max = WorldParameters.Instance.MountainHeight - 1;
        if (max / (float) heightVal <= .3f)
        {
            return plainTile ? lowDesertTiles[0] : lowDesertTiles[Random.Range(0, lowDesertTiles.Length)];
        }

        if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
        {
            return plainTile ? medDesertTiles[0] : medDesertTiles[Random.Range(0, medDesertTiles.Length)];
        }
        
        return plainTile ? highDesertTiles[0] : highDesertTiles[Random.Range(0, highDesertTiles.Length)];
    }

    public Tile GetRandomSavannaTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        int max = WorldParameters.Instance.MountainHeight - 1;
        if (max / (float) heightVal <= .3f)
        {
            return plainTile ? lowSavannaTiles[0] : lowSavannaTiles[Random.Range(0, lowSavannaTiles.Length)];
        }

        if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
        {
            return plainTile ? medSavannaTiles[0] : medSavannaTiles[Random.Range(0, medSavannaTiles.Length)];
        }
        
        return plainTile ? highSavannaTiles[0] : highSavannaTiles[Random.Range(0, highSavannaTiles.Length)];
    }
    
    public Tile GetRandomJungleTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        int max = WorldParameters.Instance.MountainHeight - 1;
        if (max / (float) heightVal <= .3f)
        {
            return plainTile ? lowJungleTiles[0] : lowJungleTiles[Random.Range(0, lowJungleTiles.Length)];
        }

        if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
        {
            return plainTile ? medJungleTiles[0] : medJungleTiles[Random.Range(0, medJungleTiles.Length)];
        }
        
        return plainTile ? highJungleTiles[0] : highJungleTiles[Random.Range(0, highJungleTiles.Length)];
    }
    
    public Tile GetRandomGrasslandTile(int heightVal)
    {
        bool plainTile = Random.Range(0, 100) / 100f <= WorldParameters.Instance.PlainTileChance;
        int max = WorldParameters.Instance.MountainHeight - 1;
        if (max / (float) heightVal <= .3f)
        {
            return plainTile ? lowGrassTiles[0] : lowGrassTiles[Random.Range(0, lowGrassTiles.Length)];
        }

        if (max / (float)heightVal >= .3f && max / (float)heightVal < .6f)
        {
            return plainTile ? medGrassTiles[0] : medGrassTiles[Random.Range(0, medGrassTiles.Length)];
        }
        
        return plainTile ? highGrassTiles[0] : highGrassTiles[Random.Range(0, highGrassTiles.Length)];
    }
}
