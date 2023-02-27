using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

/// <summary>
/// State for when the player tries to stealthy take over the city
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityStealthTakeOver : CityBaseState
{
	/// <summary>
	/// How long a stealth siege takes
	/// </summary>
	private const float CityStealthTakeOverTime = 600f;

	/// <summary>
	/// How long it takes for Military help to arrive
	/// </summary>
	private const float CityMilitaryHelpTime = 1000f;
	
	/// <summary>
	/// How much Climate Awareness is decreased with, every second
	/// </summary>
	private const float ClimateAwarenessDecrement = -.001f;

	/// <summary>
	/// How much Resistance is decreased with, every second
	/// </summary>
	private const float ResistanceDecrement = -0.01f;
	
	private float _time;
	
	
	public override void EnterState(CityStateManager context, City city, object args = null)
	{
		_time = 0;
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		ClimateAwareness.Add(ClimateAwarenessDecrement * Time.deltaTime);
		Resistance.Add(ResistanceDecrement * Time.deltaTime);
		
		_time += Time.deltaTime;

		if (!city.IsStealthTakeOver)
		{
			context.SwitchState(context.CThriving);
			return;
		}

		if (city.IsHostileTakeOver)
		{
			context.SwitchState(context.CHostileTakeOver, _time);
			return;
		}

		if (CityStealthTakeOverTime >= _time)
		{
			context.SwitchState(context.CTreeOccupied);
		}

		if (CityMilitaryHelpTime >= _time)
		{
			city.IsHostileTakeOver = true;
			city.IsStealthTakeOver = false;
			context.SwitchState(context.CSiege);
		}
	}

	public override void ExitState(CityStateManager context, City city)
	{
		throw new System.NotImplementedException();
	}
}
