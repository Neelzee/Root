using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is the state the city enters, when the player "attacks" it.
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public class CityHostileTakeOver : CityBaseState
{
	/// <summary>
	/// How long a siege takes
	/// </summary>
	private const float CityHostileTakeOverTime = 300f;

	/// <summary>
	/// If the player decides to switch from stealthy to hostile, the time is scaled down with this modifier
	/// </summary>
	private const float FromHostileToStealthScalar = .5f;

	/// <summary>
	/// How long til help arrives
	/// </summary>
	private const float MilitaryHelpTime = 350f;
	
	private float _time;
	public override void EnterState(CityStateManager context, City city, object args = null)
	{
		_time = args == null ? 0 : (float)args * FromHostileToStealthScalar;
	}

	public override void UpdateState(CityStateManager context, City city)
	{
		_time += Time.deltaTime;

		// If player calls of the attack, city is scared
		if (!city.IsHostileTakeOver)
		{
			context.SwitchState(context.CScared, _time);
			return;
		}

		// If enough time passes, city is taken over
		if (_time >= CityHostileTakeOverTime)
		{
			context.SwitchState(context.CTreeOccupied);
			return;
		}

		// If too much time passes, city is helped by the military
		if (_time >= MilitaryHelpTime)
		{
			context.SwitchState(context.CSiege, _time);
		}
	}

	public override void ExitState(CityStateManager context, City city)
	{
		
	}
}
