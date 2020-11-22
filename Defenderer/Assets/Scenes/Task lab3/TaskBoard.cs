using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBoard : MonoBehaviour
{

    public GameObject whiteCube;
    public GameObject blackCube;

    void Start()
    {
        for(int i = 0; i < 5; i++)
            for(int j = 0; j < 5; j++)
                if((i + j) % 2 == 0)
                    Instantiate(whiteCube, new Vector3(i, 0, j), new Quaternion(0,0,0,0), gameObject.transform);
                else Instantiate(blackCube, new Vector3(i, 0, j), new Quaternion(0, 0, 0, 0), gameObject.transform);
    }
}
