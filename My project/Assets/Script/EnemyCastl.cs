using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCastl : MonoBehaviour
{
    public int Health = 5;

    public void HitCastl()
    {
        if (Health - 1 > 0)
        {
            Health = Health - 1;
        }
        else
        {

        }
    }
}
