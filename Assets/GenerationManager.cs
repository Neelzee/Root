using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    [Header("Generate On Start")]
    [SerializeField] private bool generateOnStart;

    private void Start()
    {
        if (!generateOnStart)
        {
            return;
        }

        var tGenerator = GetComponentInChildren<TerrainGeneration>();
        tGenerator.Generate();

        var tiler = GetComponentInChildren<WorldTiler>();
        
        tiler.Tile();
    }
}
