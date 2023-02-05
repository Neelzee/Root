using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoistGenerator : MonoBehaviour
{
	[Header("Parameters")]
	[Tooltip("How many times the Simplex Noise value is added.")]
	[SerializeField] private float octaves;
	[Tooltip("Range of possible float values, (0 - 2 * amplitude) will be scaled.")]
	[SerializeField] private float amplitude;
	[SerializeField] private float frequency;
	[SerializeField] private float lacunarity;
	[SerializeField] private float persistence;
	[Tooltip("Range, output will be scaled to fit within the range, inclusive.")]

	private static SimplexNoiseGenerator _generator;

	public float Amplitude => amplitude;
	
	private void Awake()
	{
		_generator = new SimplexNoiseGenerator();
	}

	/// <summary>
	/// Returns a height value based on xy-coordinate
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public float MoistMap(int x, int y)
	{
		var pos = new Vector2Int(x, y);
		float elevation = amplitude;
		float tFrequency = frequency;
		float tAmplitude = amplitude;

		for (int k = 0; k < octaves; k++)
		{
			var sampleX = pos.x * tFrequency;
			var sampleY = pos.y * tFrequency;
			elevation += _generator.Noise(sampleX, sampleY, 0) * tAmplitude;
			tFrequency *= lacunarity;
			tAmplitude *= persistence;
		}

		return elevation;
	}
}
