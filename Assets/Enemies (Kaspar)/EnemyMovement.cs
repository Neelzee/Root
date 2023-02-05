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

    private void OnEnemiesSpawned(object sender, EventArgs a)
    {
        // Set target to a forest here
        _agent.SetDestination(FindClosestForest().transform.position);
    }

    private GameObject FindClosestForest()
    {
        GameObject[] forests = GameObject.FindGameObjectsWithTag("Forest");
        GameObject closestForest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        
        foreach (GameObject forest in forests)
        {
            Vector3 diff = forest.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestForest = forest;
                distance = curDistance;
            }
        }

        return closestForest;
    }
}
