using System;
using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour, IDamagable
{
    int _maxHealth = 1;
    [SerializeField] int _health;
    [SerializeField] float deathDuration = 3f;
    [SerializeField] Material destroyMaterial;

    [SerializeField] AudioClip breakSound;
    Material _currentMaterial;
    float _dissolveAmount;

    void Start()
    {
        _currentMaterial = GetComponent<Renderer>().material;
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            StartCoroutine(Death());
            AudioManager.Instance.PlaySFX(breakSound);
            Destroy(this.gameObject, 1f);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _health = _maxHealth;
    }

    IEnumerator Death()
    {
        float elapsedTime = 0;

        _currentMaterial = destroyMaterial;        

        while (elapsedTime < deathDuration)
        {
            elapsedTime += Time.fixedDeltaTime;
            _dissolveAmount = Mathf.Lerp(0f, 1f, elapsedTime / deathDuration);
            
            destroyMaterial.SetFloat("_DissolveAmount", _dissolveAmount);

            yield return null;
        }
    }
}
