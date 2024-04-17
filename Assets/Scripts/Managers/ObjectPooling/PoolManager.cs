using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;

        private Dictionary<IPoolable, PoolHandler> poolDictionary = new Dictionary<IPoolable, PoolHandler>();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
        }

        public IPoolable Spawn(IPoolable prefab, Vector3 position, Quaternion rotation)
        {
            //check if the ipoolable has already been added to the pool
            if (!poolDictionary.ContainsKey(prefab))
            {
                InitQueue(prefab);
            }
            //if more items are needed than wthe ones created initially add them to the queue
            if (poolDictionary[prefab].Poolables.Count < 1)
            {
                AddToQueue(prefab);
            }
            //get the item from the queue and set it active
            IPoolable itemFetched = poolDictionary[prefab].ItemFetch();
            GameObject objectFetched = itemFetched.GameObject;
            objectFetched.SetActive(true);
            objectFetched.transform.position = position;
            objectFetched.transform.rotation = rotation;
            return itemFetched;
        }

        public void ReturnToPool(IPoolable prefab)
        {
            if (!poolDictionary.ContainsKey(prefab))
            {
                Debug.LogError("Trying to return an object outside of pool");
            }
            poolDictionary[prefab].ItemReturn();
        }

        //this method is called when we are pooling an object thats not in our queue already
        private void InitQueue(IPoolable prefab)
        {
            // we add the prefab we are trying to instantiate to our dictionary
            // generating its handler which keeps created, active and inactive objects
            poolDictionary.Add(prefab, new PoolHandler(prefab, prefab.PoolSize));
            AddToQueue(prefab);
        }

        private void AddToQueue(IPoolable prefab)
        {

            // we iterate through the queue instantiating all the items on it and set them inactive
            for (int i = 0; i < 10; i++)
            {
                GameObject createdObj = Instantiate(prefab.GameObject, this.gameObject.transform);
                createdObj.SetActive(false);
                IPoolable poolRef = createdObj.GetComponent<IPoolable>();
                poolDictionary[prefab].AddToPool(poolRef);
            }
        }

    }
}