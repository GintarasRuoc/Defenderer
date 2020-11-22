using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private PlayerCore core;
    private Vector3 newPosition;
    public GameObject PointParent;

    void Start()
    {
        core = GameObject.Find("Player").GetComponent<PlayerCore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //core.MoneyChange(1);

        AddNewPoint();
        Destroy(gameObject);
        Debug.Log("Player touched me");
        
    }

    private void AddNewPoint()
    {
        float x = Random.Range(-2f, 30f);
        float z = Random.Range(-7, 20);
        if(x <= 7f && z <= 2f)
        {
            x = 8f;
            z = 3f;
        }
        float y = Random.Range(1, 3);
        if (y == 1)
            y = 2.8f;
        else
            y = 10.5f;
        newPosition = new Vector3(x, y, z);
        Instantiate(this, newPosition, new Quaternion(0,0,0,0), PointParent.transform);
    }
    // laiptai
    // x -2 iki 7
    // y -7 iki 2


    // x -2 ->> 30
    // y -7 ->> 20
}
