using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    Animator anim;
    public float reachRange = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] Player;
        Player = Physics.OverlapSphere(transform.position, reachRange);
        foreach (Collider col in Player)
            if (col.name == "Player")
                if (Input.GetKeyDown("e"))
                    anim.Play("Action");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, reachRange);
    }
}
