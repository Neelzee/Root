using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySiege : CityBaseState
{
    /// <summary>
    /// How long a siege takes
    /// </summary>
    private const float SiegeTime = 1000f;
    
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
    
    public override void EnterState(CityStateManager context, City city, object args = null)
    {
        ClimateAwareness.ScaleValue(ClimateAwarenessScalar);
        Resistance.ScaleValue(ResistanceScalar);
    }

    public override void UpdateState(CityStateManager context, City city)
    {
        ClimateAwareness.Add(ClimateAwarenessIncrement * Time.deltaTime);
        Resistance.Add(ResistanceIncrement * Time.deltaTime);
        
        if (!city.IsHostileTakeOver)
        {
            city.IsHostileTakeOver = false;
            context.SwitchState(context.CMilitaryOccupied);
        }

        if (!(_time >= SiegeTime))
        {
            return;
        }

        city.IsHostileTakeOver = false;
        context.SwitchState(context.CTreeOccupied);
    }

    public override void ExitState(CityStateManager context, City city)
    {
        throw new System.NotImplementedException();
    }
}
