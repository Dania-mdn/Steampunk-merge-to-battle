using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 1;
        health = PlayerPrefs.GetInt("swordHP");
        damage = PlayerPrefs.GetInt("swordDamage");
        slider.maxValue = health;
        slider.value = health;
    }
}
