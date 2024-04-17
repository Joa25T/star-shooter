using System.Collections;
using UnityEngine;

public class BasicLaser : PooledObject
{
    [Header("Movement")]
    [SerializeField] private float _speed = 18f;
    [SerializeField] private float _lifeSpan = 4.5f;

    //calculated properties
    private float ActualSpeed => _speed * Time.deltaTime;
    private Vector3 Velocity => new Vector3(0, ActualSpeed, 0);

    //gets called everytime an object becomes active
    private void OnEnable()
    {
        // return to pool after the _lifeSpan has passed
        StartCoroutine(DeactivateAfterLifeSpan());
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Velocity);
    }

    private void OnCollisionEnter(Collision other) 
    {
        StopCoroutine(DeactivateAfterLifeSpan());
        ReturnToPool();
    }

    private IEnumerator DeactivateAfterLifeSpan()
    {
        yield return new WaitForSeconds(_lifeSpan);
        ReturnToPool();
    }
}
