using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class GunUpgradeClass
{
    public int unlockCost;
    public Text unlockCostText;
    public GameObject protection;

    public float fillDmg = 0f;
    public int upgradeDmgCost;
    public int currentDmg;
    public int upgradeDmg;

    public Image dmgFill;
    public Text upgradeDmgCostText;
    public Text currentDmgText;
    public Text upgradeDmgText;

    public float fillMag = 0f;
    public int upgradeMagCost;
    public int currentMag;
    public int upgradeMag;

    public Image upgFill;
    public Text upgradeMagCostText;
    public Text currentMagText;
    public Text upgradeMagText;

    public void Change()
    {
        upgradeDmgCostText.text = upgradeDmgCost.ToString();
        currentDmgText.text = currentDmg.ToString();
        upgradeDmgText.text = upgradeDmg.ToString();

        upgradeMagCostText.text = upgradeMagCost.ToString();
        currentMagText.text = currentMag.ToString();
        upgradeMagText.text = upgradeMag.ToString();
        if (unlockCostText != null)
        {
            unlockCostText.text = unlockCost.ToString();
        }
    }

    public void ChangeDmg()
    {
        currentDmg += upgradeDmg;
        fillDmg += 0.2f;
        currentDmgText.text = currentDmg.ToString();
        dmgFill.fillAmount = fillDmg;

        if(fillDmg >= 1f)
        {
            upgradeDmg = 0;
            upgradeDmgText.text = upgradeDmg.ToString();
        }
    }

    public void ChangeMag()
    {
        currentMag += upgradeMag;
        fillMag += 0.2f;
        currentMagText.text = currentMag.ToString();
        upgFill.fillAmount = fillMag;

        if (fillMag >= 1f)
        {
            upgradeDmg = 0;
            upgradeMagText.text = upgradeMag.ToString();
        }
    }

}
