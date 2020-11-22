using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInfo : MonoBehaviour
{
    public AudioClip music;
    public bool hasMusic;
    public GameObject parent;

    

    public void changeMusic(bool change)
    {
        hasMusic = change;
    }

}
