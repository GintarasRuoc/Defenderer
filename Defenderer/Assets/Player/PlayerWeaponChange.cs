using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponChange : MonoBehaviour
{
    Animator anim;
    PlayerController controls;
    public Camera MainCamera;
    public GameObject AmmoBar;
    private HpAmmo bar;
    public AudioSource source;
    public AudioClip[] sounds;

    private bool inShop = false;

    // 1 - Pistol 2 - Machine Pistol 3 - Shotgun 4 - Submachine Gun 5 - Assault Rifle 6 - Sniper 7 - Grenade Launcher 8 - MachineGun
    public WeaponClass[] weapons;
    private int currentWeapon = 0;

    // Reload
    private float reloadingTimer = 0f;
    private bool reloading = false;

    // Shoot
    private float shootTimer = 0f;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controls = GetComponent<PlayerController>();
        weapons[currentWeapon].Model.SetActive(true);
        bar = AmmoBar.GetComponent<HpAmmo>();
        source = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inShop = !inShop;
        }
        if (inShop)
            return;
        
        //Weapon change
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (currentWeapon != 0)
                changeWeapon(0);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (currentWeapon != 1 && weapons[1].bought)
                changeWeapon(1);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (currentWeapon != 2 && weapons[2].bought)
                changeWeapon(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (currentWeapon != 3 && weapons[3].bought)
                changeWeapon(3);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (currentWeapon != 4 && weapons[4].bought)
                changeWeapon(4);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            if (currentWeapon != 5 && weapons[5].bought)
                changeWeapon(5);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            if (currentWeapon != 6 && weapons[6].bought)
                changeWeapon(6);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            if (currentWeapon != 7 && weapons[7].bought)
                changeWeapon(7);
        }

        // Reloading sequence
        if (reloadingTimer > 0)
        {
            reloadingTimer -= Time.deltaTime;
            if (shootTimer > 0)
                shootTimer -= Time.deltaTime;
            return;
        }
        if (reloading)
        {
            reloaded();
            reloading = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
            ReloadType();


        // Shooting
        if (shootTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && weapons[currentWeapon].CurrentAmmo > 0)
            {
                source.PlayOneShot(sounds[currentWeapon]);
                if (currentWeapon <= 1)
                    anim.Play("ShootPistol");
                else anim.Play("ShootRifle");
            }
            else if(Input.GetKeyDown(KeyCode.Mouse0) && weapons[currentWeapon].CurrentAmmo <= 0)
            {
                ReloadType();
            }
        }
        else shootTimer -= Time.deltaTime;

    }
    
    private void ReloadType()
    {
        if (currentWeapon <= 1)
            anim.Play("ReloadPistol");
        else anim.Play("ReloadRifle");
    }

    private void changeWeapon(int num)
    {
        anim.SetInteger("CurrentWeapon", num);
        if (currentWeapon <= 1)
            anim.Play("PutPistol");
        else anim.Play("PutRifle");
        source.clip = sounds[currentWeapon];
    }

    public void changeWeaponModel()
    {
        int num = anim.GetInteger("CurrentWeapon");
        weapons[currentWeapon].Model.SetActive(false);
        currentWeapon = num;
        controls.ChangeWeapon(num);
        weapons[currentWeapon].Model.SetActive(true);
    }

    public void reloadWeapon()
    {
        reloadingTimer = weapons[currentWeapon].ReloadTime;
        reloading = true;
        
    }

    private void reloaded()
    {
        weapons[currentWeapon].CurrentAmmo = weapons[currentWeapon].MaxAmmo;
        bar.ChangeAmmoAmount(weapons[currentWeapon].CurrentAmmo);
    }

    public void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit);
        if(hit.transform.tag == "Enemy")
            if(currentWeapon != 6)
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(weapons[currentWeapon].Damage);
            }
            else
            {
                Collider[] colliders;
                colliders = Physics.OverlapSphere(hit.transform.position, weapons[currentWeapon].ExplosionRadius);
                foreach (Collider col in colliders)
                    if (col.tag == "Enemy")
                        col.GetComponent<Enemy>().TakeDamage(weapons[currentWeapon].Damage);
            }
        weapons[currentWeapon].CurrentAmmo--;
        bar.ChangeAmmoAmount(weapons[currentWeapon].CurrentAmmo);
    }

    public void UpgradeDmg(int _weapon, int _dmg)
    {
        weapons[_weapon].Damage += _dmg;
    }

    public void UpgradeMag(int _weapon, int _mag)
    {
        weapons[_weapon].MaxAmmo += _mag;
    }

    public void UnlockWeapon(int _weapon)
    {
        weapons[_weapon].bought = true;
    }
}
