using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    private int wave;
    private int enemiesToSpawn;
    private int currentNumberOfEnemies;

    public GameObject enemy1;
    public GameObject enemy2;

    public GameObject Door1;
    public GameObject Door2;

    public Vector3 door1Offset = new Vector3(0, 0, 0);
    public Vector3 door2Offset = new Vector3(0, 0, 0);

    public GameObject text;

    private PlayMusic music;

    void Start()
    {
        wave = 1;
        currentNumberOfEnemies = 0;
        music = gameObject.GetComponent<PlayMusic>();
    }

    void Update()
    {
        if (currentNumberOfEnemies > 0 || enemiesToSpawn > 0)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            text.SetActive(false);
            AmountToSpawn();
            SpawnEnemies();
            if (wave < 10)
                music.ChangeMusic(2);
            else music.ChangeMusic(3);
        }

        if (currentNumberOfEnemies <= 0 && enemiesToSpawn <= 0)
            music.ChangeMusic(1);
    }

    void AmountToSpawn()
    {
        enemiesToSpawn = Mathf.RoundToInt(wave * 1.25f);
    }

    void SpawnEnemies()
    {
        while(enemiesToSpawn > 0)
        {
            Instantiate(ChooseEnemy(), ChooseLocation(), new Quaternion(0,0,0,0), gameObject.transform);
            enemiesToSpawn--;
            currentNumberOfEnemies++;
        }
    }

    GameObject ChooseEnemy()
    {
        if (Random.Range(1, 100) <= 50)
            return enemy1;
        else return enemy2;
    }

    Vector3 ChooseLocation()
    {
        if (Random.Range(1, 100) <= 50)
            return Door1.transform.position + door1Offset;
        else return Door2.transform.position + door2Offset;
    }

    public void enemyDied()
    {
        currentNumberOfEnemies--;
        if (currentNumberOfEnemies <= 0 && enemiesToSpawn <= 0)
        {
            wave++;
            text.SetActive(true);
        }

    }
}
