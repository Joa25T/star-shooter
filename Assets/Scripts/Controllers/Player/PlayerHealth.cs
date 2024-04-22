using UnityEngine;

public class PlayerHealth : MonoBehaviour , IDamageable
{
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private float _currentHealth;

    public float PlayersHealth => _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    
    public void DamageTaken(Damage damage)
    {
        _currentHealth -= damage.ammount;
    }

    public void Death()
    {
        Destroy(this.gameObject); 
    }
}
