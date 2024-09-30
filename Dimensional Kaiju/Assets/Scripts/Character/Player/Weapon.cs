using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int _damageAmount = 2;

    [SerializeField] CapsuleCollider2D damageCollider;

    void Start()
    {
        if (damageCollider == null)
        {
            damageCollider = gameObject.AddComponent<CapsuleCollider2D>();
            damageCollider.isTrigger = true;
            damageCollider.size = new(0.3f, 1.3f);
            damageCollider.enabled = false;
        }
        damageCollider = GetComponent<CapsuleCollider2D>();
    }

    public void EnableCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableCollider()
    {
        damageCollider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) { return; }
        
        other.gameObject.GetComponent<IDamagable>().TakeDamage(_damageAmount);
    }
}
