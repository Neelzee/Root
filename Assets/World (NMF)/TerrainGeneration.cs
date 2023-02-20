using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		var rawHeightMap = new float[size.x, size.y];
		
		var moistMap = new int[size.x, size.y];
		var rawMoistMap = new float[size.x, size.y];
		
		var tempMap = new int[size.x, size.y];
		var rawTempMap = new float[size.x, size.y];


		for (int x = 0; x < size.x; x++)
		{
			for (int y = 0; y < size.x; y++)
			{
				// Height
				{
					float val = heightGenerator.HeightMap(x, y);
					rawHeightMap[x, y] = val;
				}
				
				// Moistness
				{
					rawMoistMap[x, y] = moistGenerator.MoistMap(x, y);
				}
				
				// Temperature
				{
					rawTempMap[x, y] = tempGenerator.TempMap(x, y);
				}
			}
		}


		{
			var max = rawHeightMap.Cast<float>().Max();
			var min = rawHeightMap.Cast<float>().Min();
			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.x; y++)
				{
					heightMap[x, y] = ScaleValue(rawHeightMap[x, y], max, min, 8, 0);
				}
			}
		}

		{
			var max = rawMoistMap.Cast<float>().Max();
			var min = rawMoistMap.Cast<float>().Min();
			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.x; y++)
				{
					moistMap[x, y] = ScaleValue(rawMoistMap[x, y], max, min, 2, 0);
				}
			}
		}
		
		{
			var max = rawTempMap.Cast<float>().Max();
			var min = rawTempMap.Cast<float>().Min();
			for (int x = 0; x < size.x; x++)
			{
				for (int y = 0; y < size.x; y++)
				{
					tempMap[x, y] = ScaleValue(rawTempMap[x, y], max, min, 2, 0);
				}
			}
		}
		

		World.HeightMap = heightMap;
		World.MoistnessMap = moistMap;
		World.TempMap = tempMap;
		World.MaxHeight = 8;
		World.MinHeight = 0;
		World.Initialised = true;
	}

	public static int ScaleValue(float val, float valMax, float valMin, int desiredMax, int desiredMin)
	{
		int v = Mathf.RoundToInt((val - valMin) / (valMax - valMin) * (desiredMax - desiredMin) + desiredMin);
		return v > desiredMax ? desiredMax : v;
	}
}
