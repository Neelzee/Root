using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeInfo : MonoBehaviour
{
    public string treeName;
    [SerializeField] private Tile _forestTile;
    [SerializeField] private List<Environments> acceptedEnvironments = new List<Environments>();

    public Tile getTile()
    {
        return _forestTile;
    }
}

public enum Environments
{
    Dry,
    Wet,
    Flooded,
    LowTemperature,
    MediumTemperature,
    HighTemperature,
}
