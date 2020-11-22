using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    Animator anim;
    public float reachRange = 1f;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Collider[] Player;
        Player = Physics.OverlapSphere(transform.position, reachRange);
        foreach (Collider col in Player)
            if (col.name == "Player")
                if (Input.GetKeyDown("e"))
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                    anim.Play("Close");
                else anim.Play("Open");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, reachRange);
    }
}
