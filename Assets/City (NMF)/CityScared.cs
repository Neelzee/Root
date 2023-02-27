using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Once a certain threshold in CA is reached, cities turn scared.
/// Is based on population size, and distance too player activity.
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityScared : CityBaseState
{
	/// <summary>
	/// How high Climate Awareness must be, for the city to be scared
	/// </summary>
	private const float ScaredCaThreshold = .5f;
	
	/// <summary>
	/// What value Climate Awareness must exceed for city to "call" for help
	/// </summary>
	private const float CityMilitaryHelpCaVal = .7f;

	/// <summary>
	/// How Long it takes for the Military to arrive
	/// </summary>
	private const float MilitaryArrivalTime = 600f;

	/// <summary>
	/// How long it takes for a city to be calmed
	/// </summary>
	private const float CalmnessTime = 2000f;
	
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
	
	private float _time;

	public override void EnterState(CityStateManager context, City city, object args)
	{
		_time = args == null ? 0 : (float)args;
		
		if (ClimateAwareness.ClimateAwarenessValue >= CityMilitaryHelpCaVal)
		{
			_time = 0;
		}
		
		ClimateAwareness.ScaleValue(ClimateAwarenessScalar);
		Resistance.ScaleValue(ResistanceScalar);
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		_time += Time.deltaTime;
		
		ClimateAwareness.Add(ClimateAwarenessIncrement * Time.deltaTime);
		Resistance.Add(ResistanceIncrement * Time.deltaTime);

		if (city.IsHostileTakeOver)
		{
			context.SwitchState(context.CHostileTakeOver, CityMilitaryHelpCaVal >= ClimateAwareness.ClimateAwarenessValue ? _time : 0);
		}
		

		// If city is scared long enough, military arrives
		if (MilitaryArrivalTime <= _time && CityMilitaryHelpCaVal >= ClimateAwareness.ClimateAwarenessValue)
		{
			context.SwitchState(context.CMilitaryOccupied);
			return;
		}

		// If city is scared, but not too scared, they calm down
		if (CalmnessTime <= _time && ClimateAwareness.ClimateAwarenessValue <= ScaredCaThreshold)
		{
			context.SwitchState(context.CThriving);
		}
		
	}

	public override void ExitState(CityStateManager context, City city)
	{
		throw new System.NotImplementedException();
	}
}
