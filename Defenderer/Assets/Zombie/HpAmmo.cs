using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpAmmo : MonoBehaviour
{

    public Image PlayerHealthBar;
    public Image BedHealthBar;
    public Text AmmoAmount;

    public void ChangePlayerHealth(float pct)
    {
        Debug.Log(pct + " player");
        PlayerHealthBar.fillAmount = pct;
    }

    public void ChangeBedHealth(float pct)
    {
        Debug.Log(pct + " bed");
        BedHealthBar.fillAmount = pct;
    }

    public void ChangeAmmoAmount(int amount)
    {
        AmmoAmount.text = amount.ToString();
    }
}
