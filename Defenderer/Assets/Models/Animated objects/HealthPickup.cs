using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Vector3 newPosition;
    public GameObject PointParent;
    public ParticleSystem explosion;
    public GameObject player;
    private PlayerCore core;
    public GameObject bed;
    private BedHp bedHp;

    private void Start()
    {
        core = player.GetComponent<PlayerCore>();
        bedHp = bed.GetComponent<BedHp>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            AddNewPoint();
            explosion.transform.position = transform.position;
            explosion.Play();
            if (core.FullHP())
                bedHp.ChangeHp(2);
            else core.ChangeHp(2);
            Destroy(gameObject);

            Debug.Log("Health picked up");
        }

    }

    private void AddNewPoint()
    {
        float x = Random.Range(-2f, 30f);
        float z = Random.Range(-7, 20);
        if (x <= 7f && z <= 2f)
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
        Debug.Log(newPosition.ToString());
        Instantiate(this, newPosition, new Quaternion(0, 0, 0, 0), PointParent.transform);
    }
}
