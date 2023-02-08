using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGenerator : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("How many times the Simplex Noise value is added.")]
    [SerializeField] private float octaves;
    [Tooltip("Range of possible float values, (0 - 2 * amplitude) will be scaled.")]
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float lacunarity;
    [SerializeField] private float persistence;

    private static SimplexNoiseGenerator _generator;

    private static RiverGenerator _instance;

    public static RiverGenerator Instance => _instance;

    private void Awake()
    {
        _generator = new SimplexNoiseGenerator();
        _instance = this;
    }

    /// <summary>
    /// Returns a noise value based on xy-coordinate
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public float RiverMap(float x, float y)
    {
        var pos = new Vector2(x, y);
        float elevation = amplitude;
        float tFrequency = frequency;
        float tAmplitude = amplitude;
        float ampSum = 0;

        for (int k = 0; k < octaves; k++)
        {
            var sampleX = pos.x * tFrequency;
            var sampleY = pos.y * tFrequency;
            elevation += _generator.Noise(sampleX, sampleY, 0) * tAmplitude;
            tFrequency *= lacunarity;
            tAmplitude *= persistence;
            ampSum += tAmplitude;
        }

        return elevation / ampSum;
    }
}
