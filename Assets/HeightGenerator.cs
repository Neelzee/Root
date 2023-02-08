using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeightGenerator : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] private Vector2Int offsetRange;
	[SerializeField] private float magnification;

	private Vector2 _offset;

	private void Awake()
	{
		_offset = new Vector2(Random.Range(offsetRange.x, offsetRange.y), Random.Range(offsetRange.x, offsetRange.y));
	}

	/// <summary>
	/// Returns a height value based on xy-coordinate
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public float HeightMap(int x, int y)
	{
		return Mathf.PerlinNoise((x - _offset.x) / magnification, (y - _offset.y) / magnification);
	}
}
