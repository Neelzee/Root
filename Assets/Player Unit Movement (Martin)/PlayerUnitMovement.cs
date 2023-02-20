using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerUnitMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    // Uncomment to test combat
    // Enemy enemy;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

    }

    public void MoveTo(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    // Uncomment to test combat
    // void Update()
    // {
    //     enemy = FindObjectOfType<Enemy>();
    //     if(enemy != null && Vector2.Distance(enemy.transform.position, transform.position) < 4f)
    //     {
    //         enemy.TakeDamage((int)(1 * Time.deltaTime));
    //     }
    // }
}
