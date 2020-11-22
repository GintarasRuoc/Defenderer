using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventHandler : MonoBehaviour
{
    private PlayerWeaponChange weapons;

    private void Start()
    {
        weapons = GetComponentInParent<PlayerWeaponChange>();
    }

    void ReloadPistol()
    {
        weapons.reloadWeapon();
    }

    void ReloadRifle()
    {
        weapons.reloadWeapon();
    }

    void TakePistol()
    {
        weapons.changeWeaponModel();
    }

    void TakeRifle()
    {
        weapons.changeWeaponModel();
    }

    void ShootPistol()
    {
        weapons.Shoot();
    }

    void ShootRifle()
    {
        weapons.Shoot();
    }
}
