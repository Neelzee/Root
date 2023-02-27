using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// City is occupied, and produces resources for the player
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityTreeOccupied : CityBaseState
{

	/// <summary>
	/// How much energy is produced each second
	/// </summary>
	private const float EnergyScalar = .5f;

	/// <summary>
	/// How much water is produced each second
	/// </summary>
	private const float WaterScalar = .5f;

	/// <summary>
	/// How much nutrients is produced each second
	/// </summary>
	private const float NutrientsScalar = .5f;

	public override void EnterState(CityStateManager context, City city, object args = null)
	{
		
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		// TODO: Implement resource production each update
	}

	public override void ExitState(CityStateManager context, City city)
	{
		throw new System.NotImplementedException();
	}
}
