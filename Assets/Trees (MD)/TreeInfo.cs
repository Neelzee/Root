using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeInfo : MonoBehaviour
{
    [SerializeField] private Tile _forestTile;
    [SerializeField] private List<>();

    public Tile getTile()
    {
        return _forestTile;
    }
}

public enum Habitable
{
    Dry,
    Wet,
    Flooded,
    LowTemperature,
    MediumTemperature,
    HighTemperature,
}
