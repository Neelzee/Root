using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// "base" city state
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityThriving : CityBaseState
{
	/// <summary>
	/// How high Climate Awareness must be, before the City State goes to Scared
	/// </summary>
	private const float ScaredCaThreshold = .5f;
	
	/// <summary>
	/// How long it takes for a city to go to Scared state
	/// </summary>
	private const float ScaredTimeThreshold = 300f;
	
	/// <summary>
	/// How much Climate Awareness is decreased with, every second
	/// </summary>
	private const float ClimateAwarenessDecrement = -.001f;

	/// <summary>
	/// How much Resistance is decreased with, every second
	/// </summary>
	private const float ResistanceDecrement = -0.01f;

	private float _time;
	
	/*
	 * What should CityThriving do in enter state?
	 */
	public override void EnterState(CityStateManager context, City city, object args = null)
	{
		_time = args == null ? 0 : (float)args;
	}

	/*
	 * Check if it should go to a new state
	 */
	public override void UpdateState(CityStateManager context, City city)
	{
		ClimateAwareness.Add(ClimateAwarenessDecrement * Time.deltaTime);
		Resistance.Add(ResistanceDecrement * Time.deltaTime);
		
		if (_time < 0)
		{
			_time = 0;
		}
		
		if (ScaredCaThreshold <= ClimateAwareness.ClimateAwarenessValue)
		{
			_time += Time.deltaTime;
			if (_time >= ScaredTimeThreshold)
			{
				context.SwitchState(context.CScared);
			}
		}
		else
		{
			_time -= Time.deltaTime;
		}

		if (city.IsHostileTakeOver)
		{
			context.SwitchState(context.CHostileTakeOver);
		}
		
		if (city.IsStealthTakeOver)
		{
			context.SwitchState(context.CStealthTakeOver);
		}
	}

	public override void ExitState(CityStateManager context, City city)
	{
		
	}
}
