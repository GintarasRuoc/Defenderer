using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    public GameObject guns;
    public GameObject HpBar;
    private HpAmmo bar;

    public int MaxHp = 10;
    private int Hp;

    void Start()
    {
        Hp = MaxHp;
        bar = HpBar.GetComponent<HpAmmo>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            guns.active = !guns.active;
    }

    public void ChangeHp(int amount)
    {
        Hp += amount;
        Debug.Log(Hp / MaxHp + " player");
        bar.ChangePlayerHealth((float)Hp / (float)MaxHp);
        if (Hp <= 0)
            GameOver();
    }

    private void GameOver()
    {
        GameObject.Find("Enemies").GetComponent<Score>().GameOver();
    }

    public bool FullHP()
    {
        if (Hp < MaxHp)
            return false;
        else return true;
    }
}
