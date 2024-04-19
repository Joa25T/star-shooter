using System.Collections;
using UnityEngine;

public class BasicLaser : PooledObject
{
    [Header("Movement")]
    [SerializeField] private float _speed = 18f;
    [SerializeField] private float _lifeSpan = 4.5f;

    [Header("Weapon")]
    [SerializeField] private Damage _damage;

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
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable objectHit))
        {
            objectHit.DamageTaken(_damage);
        }
        ReturnToPool();
    }

    private IEnumerator DeactivateAfterLifeSpan()
    {
        yield return new WaitForSeconds(_lifeSpan);
        ReturnToPool();
    }
}