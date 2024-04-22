using ObjectPooling;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Weapon _weapon;
    [SerializeField] private Transform _firePosition;

    private float _lastFire;

    //calculate the time until our next fire is available
    public float _canFire => _lastFire + _weapon.fireRate;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            TryFire();
        }
    }

    private void TryFire()
    {
        if(Time.time > _canFire)
        {
            _lastFire = Time.time;
            Fire();
        }
    }

    private void Fire()
    {
        PoolManager.Instance.Spawn(_weapon.prefab, _firePosition.position, Quaternion.identity);
    }
}
