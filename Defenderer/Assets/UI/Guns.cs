using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    public GameObject player;
    private PlayerWeaponChange upg;
    private int money;
    private int currentOpenTab;

    public Text moneyInfo;

    public GunUpgradeClass[] gunUpgrades;

    void Start()
    {
        currentOpenTab = 0;
        upg = player.GetComponent<PlayerWeaponChange>();
        money = 3000;
        moneyInfo.text = money.ToString();
    }

    

    public void ChangeTab(int tab)
    {
        currentOpenTab = tab;
        gunUpgrades[currentOpenTab].Change();
    }

    public void UpgradeDmg()
    {
        int cost = gunUpgrades[currentOpenTab].upgradeDmgCost;
        if (money >= cost && gunUpgrades[currentOpenTab].fillDmg < 1f)
        {
            ChangeMoney(-cost);
            upg.UpgradeDmg(currentOpenTab, gunUpgrades[currentOpenTab].upgradeDmg);
            gunUpgrades[currentOpenTab].ChangeDmg();
        }
    }

    public void UpgradeMag()
    {
        int cost = gunUpgrades[currentOpenTab].upgradeMagCost;
        if (money >= cost && gunUpgrades[currentOpenTab].fillMag < 1f)
        {
            ChangeMoney(-cost);
            upg.UpgradeMag(currentOpenTab, gunUpgrades[currentOpenTab].upgradeMag);
            gunUpgrades[currentOpenTab].ChangeMag();
        }
    }

    public void ChangeMoney(int amount)
    {
        money += amount;
        
        moneyInfo.text = money.ToString();
    }

    public void UnlockWeapon()
    {
        int cost = gunUpgrades[currentOpenTab].unlockCost;
        if (money >= gunUpgrades[currentOpenTab].unlockCost)
        {
            upg.UnlockWeapon(currentOpenTab);
            ChangeMoney(-cost);
            gunUpgrades[currentOpenTab].protection.SetActive(false);
        }
    }
}
