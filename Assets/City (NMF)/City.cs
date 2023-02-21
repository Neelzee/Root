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
    [Tooltip("How much Climate Awareness is scaled with, every second, while this city is under attack")]
    [SerializeField] private float caAttackScalar;
    [Tooltip("How much Climate Awareness is increased with, if the player fails in their attack")]
    [SerializeField] private float caAttackDefeat;
    [Tooltip("How much Climate Awareness is increased with, if the player succeeds in their attack")]
    [SerializeField] private float caAttackVictory;
    [Tooltip("How much Resistance is increased with, every second, while this city is scared")]
    [SerializeField] private float caScaredScalar;
    [Tooltip("How much Resistance is scaled with, every second, while this city is under attack")]
    [SerializeField] private float resAttackScalar;
    [Tooltip("How much Resistance is increased with, if the player fails in their attack")]
    [SerializeField] private float resAttackDefeat;
    [Tooltip("How much Resistance is increased with, if the player succeeds in their attack")]
    [SerializeField] private float resAttackVictory;
    [Tooltip("How much Resistance is increased with, every second, while this city is scared")]
    [SerializeField] private float resScaredScalar;
    [Tooltip("If the City is under Hostile Take Over")]
    [SerializeField] private bool isHostileTakeOver;
    [Tooltip("If the City is under Stealth Take Over")]
    [SerializeField] private bool isStealthTakeOver;
    
    private PolygonCollider2D _polygonCollider2D;
    
    public int CityPop => cityPop;

    public float CaAttackScalar => caAttackScalar;

    public float CaAttackDefeat => caAttackDefeat;

    public float CaAttackVictory => caAttackVictory;

    public float CaScaredScalar => caScaredScalar;

    public float ResAttackScalar => resAttackScalar;

    public float ResAttackDefeat => resAttackDefeat;

    public float ResAttackVictory => resAttackVictory;

    public float ResScaredScalar => resScaredScalar;

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
