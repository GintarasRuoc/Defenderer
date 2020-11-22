using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEventHandler : MonoBehaviour
{
    public ParticleSystem fire;

    private void LightTheFire()
    {
        fire.gameObject.SetActive(true);
    }
}
