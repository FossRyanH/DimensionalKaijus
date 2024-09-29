using System;
using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour, IDamagable
{
    int _maxHealth = 3;
    [SerializeField] int _health;
    [SerializeField] float deathDuration = 3f;
    float _dissolveAmount;

    public event Action OnDeath;

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            StartCoroutine(Death());
            Destroy(this.gameObject, 1f);
            OnDeath?.Invoke();
        }
        Debug.Log($"{_health} remaining on {this.gameObject.name}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _health = _maxHealth;
    }

    IEnumerator Death()
    {
        float elapsedTime = 0;
        Material deathMaterial = GetComponent<Renderer>().material;

        while (elapsedTime < deathDuration)
        {
            elapsedTime += Time.fixedDeltaTime;
            _dissolveAmount = Mathf.Lerp(0f, 1f, elapsedTime / deathDuration);
            
            deathMaterial.SetFloat("_DissolveAmount", _dissolveAmount);

            yield return null;
        }
    }
}
