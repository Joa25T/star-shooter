using ObjectPooling;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField]protected int _poolSize =20;
    
    public int PoolSize => _poolSize;
    public GameObject GameObject => this.gameObject;

    protected void ReturnToPool()
    {
        PoolManager.Instance.ReturnToPool(this);
    }

    protected void Spawn(Vector3 position, Quaternion rotation)
    {
        PoolManager.Instance.Spawn(this, position, rotation);
    }
}
