using UnityEngine;

public class Pot : MonoBehaviour, IDamagable
{
    int _maxHealth = 3;
    int _health;

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Destroy(this.gameObject, 0.3f);
        }
        Debug.Log($"{_health} remaining on {this.gameObject.name}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Weapon.OnDealDamage += TakeDamage;
        _health = _maxHealth;
    }

    void OnDisable()
    {
        Weapon.OnDealDamage -= TakeDamage;
    }
}
