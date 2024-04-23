using System.Collections;
using ObjectPooling;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Parameters")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _enemySpawnInterval = 3f;

    private WaitForSeconds _spawnIntervalTimer;

    // Start is called before the first frame update
    void Start()
    {
        _spawnIntervalTimer = new WaitForSeconds(_enemySpawnInterval);
        StartCoroutine(SpawnEnmiesRandomly());
    }

    private IEnumerator SpawnEnmiesRandomly()
    {
        while (PlayerHealth.PlayerAlive)
        {
            PoolManager.Instance.Spawn(_enemy.prefab, _enemy.SpawnPosition, Quaternion.identity);
            yield return _spawnIntervalTimer;
        }
    }
}
