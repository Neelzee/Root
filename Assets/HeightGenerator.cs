using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightGenerator : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] private Vector2 offset;
	[SerializeField] private float magnification;

	/// <summary>
	/// Returns a height value based on xy-coordinate
	/// </summary>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <returns></returns>
	public float HeightMap(int x, int y)
	{
		return Mathf.PerlinNoise((x - offset.x) / magnification, (y - offset.y) / magnification);
	}
}
