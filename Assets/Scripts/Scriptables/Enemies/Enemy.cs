using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public PooledObject prefab;
    [SerializeField] private float _spawnLimitX =9.37f;
    [SerializeField] private float _spawnPosY =5.5f;

    public Vector3 SpawnPosition => new Vector3(Random.Range(-_spawnLimitX,_spawnLimitX), _spawnPosY, 0);
}
