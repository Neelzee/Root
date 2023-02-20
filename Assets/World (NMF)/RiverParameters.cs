using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RiverParameters : MonoBehaviour
{
    [Header("Perlin Noise")]
    [SerializeField] private Vector2 offset;
    [SerializeField] private float magnification;
    
    [Header("River")]
    [SerializeField] private bool convergence;
    [SerializeField] private int riverLength;

    public int RiverLength => riverLength;

    public bool Convergence => convergence;

    public Vector2 Offset => offset;

    public float Magnification => magnification;

    private static RiverParameters _instance;

    public static RiverParameters Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }
}
