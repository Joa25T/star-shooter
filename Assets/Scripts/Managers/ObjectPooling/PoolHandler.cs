using System.Collections.Generic;

namespace ObjectPooling
{
    public class PoolHandler
    {
        private PooledObject _prefab;
        public Queue<PooledObject> Poolables;
        public PoolHandler(PooledObject prefab)
        {
            _prefab = prefab;
            Poolables = new Queue<PooledObject>();
        }

        // gets called to populate the queue 
        // or when an item is destroyed and returns to the pool
        public void AddToPool(PooledObject poolable)
        {
            Poolables.Enqueue(poolable);
        }

        //gets called when an item from the pool has been fetched and is on the scene
        public PooledObject GetFromPool()
        {
            return Poolables.Dequeue();
        }
    }
}
  