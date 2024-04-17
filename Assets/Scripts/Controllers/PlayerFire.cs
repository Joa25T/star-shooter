using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private PooledObject _bullet;
    [SerializeField] private Transform _firePosition;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PoolManager.Instance.Spawn(_bullet, transform.position, Quaternion.identity);
        }
    }
}
