using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    public EnemyBase enemyBase;

    private void Start()
    {
       _agent = GetComponent<NavMeshAgent>();
       _agent.updateRotation = false;
       _agent.updateUpAxis = false;
       
       enemyBase.CallEnemiesSpawned += OnEnemiesSpawned;
    }

    void OnEnemiesSpawned(object sender, EventArgs a)
    {
        // Set target to a forest here
        _agent.SetDestination(Vector3.zero);
    }
}
