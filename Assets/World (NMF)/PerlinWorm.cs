using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PerlinWorm
{
    private Vector2 currentDirection;
    private Vector2 currentPosition;
    private Vector2 convergancePoint;
    private bool moveToConvergancepoint;
    private float weight = 0.6f;

    public PerlinWorm(Vector2 startPosition, Vector2 convergancePoint)
    {
        currentDirection = Random.insideUnitCircle.normalized;
        currentPosition = startPosition;
        this.convergancePoint = convergancePoint;
        moveToConvergancepoint = true;
    }

    public PerlinWorm(Vector2 startPosition)
    {
        currentDirection = Random.insideUnitCircle.normalized;
        currentPosition = startPosition;
        moveToConvergancepoint = false;
    }

    public Vector2 MoveTowardsConvergencePoint()
    {
        Vector3 direction = GetPerlinNoiseDirection();
        var directionToConvergencePoint = (convergancePoint - currentPosition).normalized;
        var endDirection = ((Vector2)direction * (1 - weight) + directionToConvergencePoint * weight).normalized;
        currentPosition += endDirection;
        return currentPosition;
    }

    public Vector2 Move()
    {
        Vector3 direction = GetPerlinNoiseDirection();
        currentPosition += (Vector2)direction;
        return currentPosition;
    }

    private Vector3 GetPerlinNoiseDirection()
    {
        float noise = RiverGenerator.Instance.RiverMap(currentPosition.x, currentPosition.y);
        float degrees = -90 + noise * -180;
        currentDirection = (Quaternion.AngleAxis(degrees, Vector3.forward) * currentDirection).normalized;
        return currentDirection;
    }

    public List<Vector2> MoveLength(int length)
    {
        var list = new List<Vector2>();
        foreach (var item in Enumerable.Range(0, length))
        {
            if (moveToConvergancepoint)
            {
                var result = MoveTowardsConvergencePoint();
                list.Add(result);
                if (Vector2.Distance(convergancePoint, result) < 1)
                {
                    break;
                }
            }
            else
            {
                var result = Move();
                list.Add(result);
            }
        }

        if (!moveToConvergancepoint)
        {
            return list;
        }

        while (Vector2.Distance(convergancePoint, currentPosition) > 1)
        {
            weight = 0.9f;
            var result = MoveTowardsConvergencePoint();
            list.Add(result);
            if (Vector2.Distance(convergancePoint, result) < 1)
            {
                break;
            }
        }

        return list;
    }
}
