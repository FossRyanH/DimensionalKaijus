using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static event Action<int> OnDealDamage;
    int _damageAmount = 2;

    [SerializeField] Collider2D damageCollider;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player")) { return; }

        if (other is IDamagable damagable)
        {
            OnDealDamage?.Invoke(_damageAmount);
            Debug.Log($"{other.gameObject.name} took damage!");
        }
    }
}
