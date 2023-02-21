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

	private const float CityMilitaryHelpTime = 1000f;
	
	private float _time;
	
	
	public override void EnterState(CityStateManager context, City city, object args = null)
	{
		_time = 0;
	}

	public override void UpdateState(CityStateManager context, City city)
	{
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
