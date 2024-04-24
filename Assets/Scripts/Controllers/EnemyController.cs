using UnityEngine;

//serves as parent script for enemies to inherit from
public class EnemyController : PooledObject, IDamageable
{
    [Header("Life")]
    [SerializeField] protected float _maxHealthPoints = 50;
    protected float _currentHealthPoints;
    [SerializeField] protected Damage _onCollisionDamage = new Damage(10, Damage.DmgType.normal);

    [Header("Movement")]
    [SerializeField] protected float _speed = 4f;
    [SerializeField] protected Vector3 _moveDir = Vector3.down;
    [SerializeField] protected float _spawnPosY = 5.5f;
    [SerializeField] protected float _spawnLimitX = 9.5f;
    [SerializeField] protected float _limitYMin = 5.5f;

    // movement calculating properties
    protected float ActualSpeed => _speed * Time.deltaTime;
    protected Vector3 Velocity => _moveDir * ActualSpeed;
    protected Vector3 RespawnPosition => new Vector3(Random.Range(-_spawnLimitX, _spawnLimitX), _spawnPosY, 0);

    protected virtual void OnEnable()
    {
        //reset the hp of the when its activated
        _currentHealthPoints = _maxHealthPoints;
    }

    // private void RandomRotate()
    // {
    //     transform.rotation =
    // }

    ///overridable move method called every update
    protected virtual void Update()
    {
        Move();
        if (transform.position.y < _limitYMin && PlayerHealth.PlayerAlive)
        {
            OnReachedEnd();
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Velocity);
    }

    //overridable method called when the enemy has reached the bottom of the screen.
    protected virtual void OnReachedEnd()
    {
        transform.position = RespawnPosition;
    }

    public void DamageTaken(Damage damage)
    {
        _currentHealthPoints -= damage.ammount;
        if (_currentHealthPoints <= 0)
        {
            Death();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        if (other.transform.parent.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.DamageTaken(_onCollisionDamage);
        }
        Death();
    }

    public void Death()
    {
        ReturnToPool();
    }

}