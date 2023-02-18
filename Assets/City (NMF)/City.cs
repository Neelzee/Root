using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class City : MonoBehaviour
{
    [Header("City Info")]
    [SerializeField] private string cityId;
    [SerializeField] private int cityPop;
    [SerializeField] private Vector3Int tmPosition;

    private PolygonCollider2D _polygonCollider2D;

    public int CityPop => cityPop;

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
