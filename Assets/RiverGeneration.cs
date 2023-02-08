using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RiverGeneration : MonoBehaviour
{
    public void GenerateRivers()
    {
        
    }

    private List<Vector2> CreateRiver(Vector2 startPos, IEnumerable<Vector2> waterMinima)
    {
        PerlinWorm worm;
        if (RiverParameters.Instance.Convergence)
        {
            var closestWaterPos = waterMinima.OrderBy(pos => Vector2.Distance(pos, startPos)).First();
            worm = new PerlinWorm(startPos, closestWaterPos);
        }
        else
        {
            worm = new PerlinWorm(startPos);
        }

        return worm.MoveLength(RiverParameters.Instance.RiverLength);
    }
}
