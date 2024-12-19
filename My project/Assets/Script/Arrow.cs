using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 1;
        slider.maxValue = health;
        slider.value = health;
    }
}
