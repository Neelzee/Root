using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeInfo : MonoBehaviour
{
    [SerializeField] private Tile _forestTile;

    public Tile getTile()
    {
        return _forestTile;
    }
}
