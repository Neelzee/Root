using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
	public void Generate()
	{
		var heightGenerator = GetComponent<HeightGenerator>();
		var moistGenerator = GetComponent<MoistGenerator>();
		var tempGenerator = GetComponent<TemperatureGenerator>();
		var size = WorldParameters.Instance.WorldSize;
		var heightMap = new int[size.x, size.y];
		var moistMap = new int[size.x, size.y];
		var tempMap = new int[size.x, size.y];


		for (int x = 0; x < size.x; x++)
		{
			for (int y = 0; y < size.x; y++)
			{
				// Height
				{
					int val = Mathf.RoundToInt(heightGenerator.HeightMap(x, y));
					heightMap[x, y] = ScaleValue(val, heightGenerator.Amplitude + 1, 0, WorldParameters.Instance.HeightMax, 0);
				}
				
				// Moistness
				{
					int val = Mathf.RoundToInt(moistGenerator.MoistMap(x, y));
					moistMap[x, y] = ScaleValue(val, moistGenerator.Amplitude + 1, 0, 2, 0);
				}
				
				// Temperature
				{
					int val = Mathf.RoundToInt(tempGenerator.TempMap(x, y));
					tempMap[x, y] = ScaleValue(val, tempGenerator.Amplitude + 1, 0, 2, 0);
				}
			}
		}

		World.HeightMap = heightMap;
		World.MoistnessMap = moistMap;
		World.TempMap = tempMap;
		World.Initialised = true;
	}

	private int ScaleValue(float val, float valMax, float valMin, int desiredMax, int desiredMin)
	{
		int v = Mathf.RoundToInt((val - valMin) / (valMax - valMin) * (desiredMax - desiredMin) + desiredMin);
		return v > desiredMax ? desiredMax : v;
	}
}
