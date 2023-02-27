using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// City that is occupied by the military.
/// Spawns heavily armed units that guard the city
/// TODO: Implement spawning
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityMilitaryOccupied : CityBaseState
{
	/// <summary>
	/// How much Climate Awareness is increased with, every second
	/// </summary>
	private const float ClimateAwarenessIncrement = 0.01f;
	
	/// <summary>
	/// How much Resistance is increased with, every second
	/// </summary>
	private const float ResistanceIncrement = 0.01f;

	/// <summary>
	/// How much Climate Awareness is scaled with, once hostile take over is initiated
	/// </summary>
	private const float ClimateAwarenessScalar = 1.1f;
	
	/// <summary>
	/// How much Resistance is scaled with, once hostile take over is initiated
	/// </summary>
	private const float ResistanceScalar = 1.1f;
	
	
	public override void EnterState(CityStateManager context, City city, object args)
	{
		ClimateAwareness.ScaleValue(ClimateAwarenessScalar);
		Resistance.ScaleValue(ResistanceScalar);
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		ClimateAwareness.Add(ClimateAwarenessIncrement * Time.deltaTime);
		Resistance.Add(ResistanceIncrement * Time.deltaTime);
		
		if (city.IsHostileTakeOver)
		{
			context.SwitchState(context.CSiege);
		}
	}

	public override void ExitState(CityStateManager context, City city)
	{
		
	}
}
