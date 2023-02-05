using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldParameters : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("World Size in Tiles")]
    [SerializeField] private Vector2Int worldSize;
    [Tooltip("Likelihood of a any Tile being 'plain'")]
    [SerializeField] private float plainTileChance;
    [SerializeField] private int riverWidth;
    [SerializeField] private int heightMax;
    [SerializeField] private int riverHeight;
    [SerializeField] private int mountainHeight;

    private void Awake()
    {
        _instance = this;
    }

    public int RiverHeight => riverHeight;

    public int MountainHeight => mountainHeight;

    public int HeightMax => heightMax;

    public Vector2Int WorldSize => worldSize;

    public float PlainTileChance => plainTileChance;

    public int RiverWidth => riverWidth;

    private static WorldParameters _instance;

    public static WorldParameters Instance => _instance;
}
