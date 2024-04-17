using UnityEngine;

namespace ObjectPooling
{
    public interface IPoolable
    {
        public int PoolSize { get; }
        public GameObject GameObject { get; }

        abstract void Spawn(Vector3 position, Quaternion rotation);
        
        abstract void ReturnToPool();
    }
}
