using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 0;
        slider.maxValue = health;
        slider.value = health;
    }
}
