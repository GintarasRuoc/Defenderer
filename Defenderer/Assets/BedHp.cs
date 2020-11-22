using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedHp : MonoBehaviour
{
    public int maxHp = 10;
    private int hp;
    public GameObject HpBar;
    private HpAmmo bar;

    private void Start()
    {
        bar = HpBar.GetComponent<HpAmmo>();
        hp = maxHp;
    }

    public void ChangeHp(int amount)
    {
        hp += amount;
        bar.ChangeBedHealth((float)hp / (float)maxHp);
        if (hp <= 0)
            GameOver();
    }

    private void GameOver()
    {
        GameObject.Find("Enemies").GetComponent<Score>().GameOver();
    }
}
