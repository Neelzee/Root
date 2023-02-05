using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies;
    [SerializeField] private int spawnRate;
    [SerializeField] private float spawnRandomness;
    
    private float _spawnTimer;
    
    private int _currentEnemies;

    public event EventHandler CallEnemiesSpawned;
    
    private void Start()
    {
        _spawnTimer = Random.Range(0f, spawnRandomness);
    }

    private void Update()
    {
        if (_currentEnemies < maxEnemies)
        {
            if (_spawnTimer <= 0)
            {
                var spawnPoint = transform.position + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
            
                var enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                enemy.transform.parent = transform;
                enemy.GetComponent<EnemyMovement>().enemyBase = this;
            
                _currentEnemies++;
                _spawnTimer = spawnRate + Random.Range(0f, spawnRandomness);
            }
            else
            {
                _spawnTimer -= Time.deltaTime;
            }
        }
        else
        {
            AllEnemiesSpawned();
            _currentEnemies = 0;
        }
    }

    private void AllEnemiesSpawned()
    {
        CallEnemiesSpawned?.Invoke(this, EventArgs.Empty);
    }
}
