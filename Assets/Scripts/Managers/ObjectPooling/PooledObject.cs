using ObjectPooling;
using UnityEngine;

public class PooledObject : MonoBehaviour, IPoolable
{
    //Ipoolable properties
    public int PoolSize => 15;
    public GameObject GameObject => this.gameObject;

    public void ReturnToPool()
    {
        PoolManager.Instance.ReturnToPool(this);
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        PoolManager.Instance.Spawn(this, position, rotation);
    }
}
