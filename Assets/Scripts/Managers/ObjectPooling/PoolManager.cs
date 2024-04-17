using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;

        private Dictionary<PooledObject, PoolHandler> poolDictionary = new Dictionary<PooledObject, PoolHandler>();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            Instance = this;
        }

        public PooledObject Spawn(PooledObject prefab, Vector3 position, Quaternion rotation)
        {
            //check if the ipoolable has already been added to the pool
            if (!poolDictionary.ContainsKey(prefab))
            {
                InitQueue(prefab);
            }
            //if more items are needed than wthe ones created initially add them to the queue
            if (poolDictionary[prefab].Poolables.Count < 1)
            {
                AddToQueue(prefab, 1);
            }
            //get the item from the queue and set it active
            PooledObject itemFetched = poolDictionary[prefab].GetFromPool();
            GameObject objectFetched = itemFetched.GameObject;
            objectFetched.SetActive(true);
            objectFetched.transform.position = position;
            objectFetched.transform.rotation = rotation;
            return itemFetched;
        }

        public void ReturnToPool(PooledObject prefab)
        {
            if (!poolDictionary.ContainsKey(prefab))
            {
                Debug.LogError("Trying to return an object outside of pool");
            }
            poolDictionary[prefab].AddToPool(prefab);
        }

        //this method is called when we are pooling an object thats not in our queue already
        private void InitQueue(PooledObject prefab)
        {
            // we add the prefab we are trying to instantiate to our dictionary
            // generating its handler which keeps created, active and inactive objects
            poolDictionary.Add(prefab, new PoolHandler(prefab));
            AddToQueue(prefab, prefab.PoolSize);
        }

        private void AddToQueue(PooledObject prefab, int poolSize)
        {
            // we iterate through the queue instantiating all the items on it and set them inactive
            for (int i = 0; i < poolSize; i++)
            {
                PooledObject createdObj = Instantiate(prefab.GameObject, this.gameObject.transform).GetComponent<PooledObject>();
                createdObj.gameObject.SetActive(false);
                poolDictionary[prefab].AddToPool(createdObj);
            }
        }

    }
}