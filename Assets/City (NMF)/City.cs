using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Contains all the relevant information about a city,
/// that will be used by the cities states, in determining their outcomes
/// <example>
/// If a city is in a military occupation, the resistance value and/or CA value might be incremented by some factor times the city population
/// </example>
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
[RequireComponent(typeof(CityStateManager))]
public class City : MonoBehaviour
{
    [Header("City Info")]
    [SerializeField] private string cityId;
    [Tooltip("Amount of people living in the city")]
    [SerializeField] private int cityPop;  // The idea is to use this as a modifier, ie. on a hostile take over, this is the amount the CA will be increased with
    [SerializeField] private Vector3Int tmPosition;
    [Tooltip("If the City is under Hostile Take Over")]
    [SerializeField] private bool isHostileTakeOver;
    [Tooltip("If the City is under Stealth Take Over")]
    [SerializeField] private bool isStealthTakeOver;
    
    private PolygonCollider2D _polygonCollider2D;
    
    public int CityPop => cityPop;

    public bool IsHostileTakeOver
    {
        get => isHostileTakeOver;
        set => isHostileTakeOver = value;
    }

    public bool IsStealthTakeOver
    {
        get => isHostileTakeOver;
        set => isHostileTakeOver = value;
    }

    private void Awake()
    {
        var tm = GameObject.FindGameObjectWithTag("Grid").GetComponentInChildren<Tilemap>();
        var cPos = tm.WorldToCell(transform.position);
        var wPos = tm.CellToWorld(cPos);
        transform.position = wPos;
        tmPosition = cPos;
        cityId = "City " + cPos;
    }
}
