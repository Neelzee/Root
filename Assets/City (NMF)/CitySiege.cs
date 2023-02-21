using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySiege : CityBaseState
{
    private const float SiegeTime = 1000f;
    
    private float _time;
    
    public override void EnterState(CityStateManager context, City city, object args = null)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(CityStateManager context, City city)
    {
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
