using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    void Death()
    {
        Destroy(gameObject);
    }
}
