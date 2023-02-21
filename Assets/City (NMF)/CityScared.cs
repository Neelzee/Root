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

	private const float CityMilitaryHelpCAVal = .7f;

	private const float MilitaryArrivalTime = 600f;

	private const float CalmnessTime = 2000f;
	
	private float _time;

	public override void EnterState(CityStateManager context, City city, object args)
	{
		_time = args == null ? 0 : (float)args;
		
		if (ClimateAwareness.ClimateAwarenessValue >= CityMilitaryHelpCAVal)
		{
			_time = 0;
		}
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		_time += Time.deltaTime;

		if (city.IsHostileTakeOver)
		{
			context.SwitchState(context.CHostileTakeOver, CityMilitaryHelpCAVal >= ClimateAwareness.ClimateAwarenessValue ? _time : 0);
		}
		

		// If city is scared long enough, military arrives
		if (MilitaryArrivalTime <= _time && CityMilitaryHelpCAVal >= ClimateAwareness.ClimateAwarenessValue)
		{
			context.SwitchState(context.CMilitaryOccupied);
			return;
		}

		// If city is scared, but not too scared, they calm down
		if (CalmnessTime <= _time && ClimateAwareness.ClimateAwarenessValue < CityMilitaryHelpCAVal)
		{
			context.SwitchState(context.CThriving);
		}
		
	}

	public override void ExitState(CityStateManager context, City city)
	{
		throw new System.NotImplementedException();
	}
}
