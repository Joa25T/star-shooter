using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public PooledObject prefab;
    public float fireRate;
    public float accuracy;
}

