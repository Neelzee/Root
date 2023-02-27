using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Script that returns the specific Tree Tile based on a height position.
/// <para>
/// <c>
/// Author: Nils Michael
/// </c>
/// </para>
/// </summary>
public class TreeTiles : MonoBehaviour
{
	[Header("Trees")]
	[SerializeField] private Tile[] oakTiles;

	private static TreeTiles _instance;

	public static TreeTiles Instance => _instance;

	private void Awake()
	{
		_instance = this;
	}

	/// <summary>
	/// Returns a Tile based on a given position on the Tilemap,
	/// If out of bounds, or invalid position, a default tile is returned instead
	/// </summary>
	/// <param name="pos">Position on the Tilemap</param>
	/// <returns></returns>
	public Tile GetHeight(Vector3Int pos)
	{
		if (pos.x < 0 || pos.y < 0 || pos.x >= World.HeightMap.GetLength(0) || pos.y >= World.HeightMap.GetLength(1))
		{
			return oakTiles[0];
		}
		
		int index = Mathf.Clamp(World.HeightMap[pos.x, pos.y], 0, oakTiles.Length - 1);

		return oakTiles[index];
	}
}
