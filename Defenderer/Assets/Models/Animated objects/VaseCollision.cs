using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseCollision : MonoBehaviour
{

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        anim.Play("Fall");
    }
}
