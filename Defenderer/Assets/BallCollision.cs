using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{

    Rigidbody body;
    public GameObject Player;
    public float Strength = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Vector3 force = transform.position - Player.transform.position * Strength;
            Debug.Log(force);
            body.AddForce(-force);
        }
    }
}
