using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCastl : MonoBehaviour
{
    public int Health = 5;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = Health;
        slider.value = Health;
    }
    public void HitCastl()
    {
        if (Health - 1 > 0)
        {
            Health = Health - 1;
            slider.value = Health;
        }
        else
        {

        }
    }
}
