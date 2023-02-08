using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    public EnemyBase enemyBase;
    
    private GameObject _target;

    private void Start()
    {
       _agent = GetComponent<NavMeshAgent>();
       _agent.updateRotation = false;
       _agent.updateUpAxis = false;
       
       enemyBase.CallEnemiesSpawned += OnEnemiesSpawned;
    }

    private void OnEnemiesSpawned(object sender, EnemyCallEventArgs a)
    {
        _target = a.Forest;
        _agent.SetDestination(_target.transform.position);
    }
}
