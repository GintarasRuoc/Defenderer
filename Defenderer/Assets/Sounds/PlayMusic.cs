using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{


    public AudioSource as1;
    public AudioClip ac1;
    public AudioClip ac2;
    public AudioClip ac3;

    private int lastAudio = 1;
    
    void Start()
    {
        as1.loop = true;
        as1.clip = ac1;
        as1.Play();
        
    }

    public void ChangeMusic(int nr)
    {
        if(lastAudio != nr)
            if (nr == 1)
            {
                as1.Stop();
                as1.clip = ac1;
                as1.Play();
            }
            else if (nr == 2)
            {
                as1.Stop();
                as1.clip = ac2;
                as1.Play();
            }
            else if (nr == 3)
            {
                as1.Stop();
                as1.clip = ac3;
                as1.Play();
            }

    }
}
