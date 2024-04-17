using System.Collections.Generic;

namespace ObjectPooling
{
    public class PoolHandler
    {
        private IPoolable _prefab;
        public Queue<IPoolable> Poolables;
        public PoolHandler(IPoolable prefab, int size)
        {
            _prefab = prefab;
            Poolables = new Queue<IPoolable>();

            // for (int i = 0; i < size; i++)
            // {
            //     Poolables.Enqueue(prefab);
            // }
        }

        //gets called when an item from the pool has been fetched and is on the scene
        public IPoolable ItemFetch()
        {
            return Poolables.Dequeue();
        }

        // gets called when an item is destroyed and returns to the pool
        public void ItemReturn()
        {
            Poolables.Enqueue(_prefab);
        }

        public void AddToPool(IPoolable poolable)
        {
            Poolables.Enqueue(poolable);
        }
    }
}
