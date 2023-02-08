using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WorldParameters : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("World Size in Tiles")]
    [SerializeField] private Vector2Int worldSize;
    [Tooltip("Likelihood of a any Tile being 'plain', as a percentage")]
    [SerializeField] private float plainTileChance;
    [Tooltip("Where lakes will appear, starts at minimum height value, and up to minimum height value + lakeHeight")]
    [SerializeField] private int lakeHeight;
    [Tooltip("Where mountains will appear, starts at maximum height value, and down to maximum height value - mountainHeight")]
    [SerializeField] private int mountainHeight;

    private void Awake()
    {
        _instance = this;
    }

    public int LakeHeight => lakeHeight;

    public int MountainHeight => mountainHeight;

    public Vector2Int WorldSize => worldSize;

    public float PlainTileChance => plainTileChance;


    private static WorldParameters _instance;

    public static WorldParameters Instance => _instance;
}
