using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponClass
{
    public GameObject Model;
    public int MaxAmmo;
    public int CurrentAmmo;
    public int Damage;
    public float TimeBetweenShots;
    public float ReloadTime;
    public float ExplosionRadius;

    public bool bought = false;
}
