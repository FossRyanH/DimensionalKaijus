using UnityEngine;

public class Equip : MonoBehaviour
{
    [SerializeField] Weapon _weaponSlot;

    void Awake()
    {
        _weaponSlot = GetComponentInChildren<Weapon>();
    }

    public void EnableWeaponCollider()
    {
        _weaponSlot.EnableCollider();
    }

    public void DisableWeaponCollider()
    {
        _weaponSlot.DisableCollider();
    }
}
