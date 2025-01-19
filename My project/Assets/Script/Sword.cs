using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 0;
        health = PlayerPrefs.GetInt("swordHP");
        damage = PlayerPrefs.GetInt("swordDamage");
        slider.maxValue = health;
        slider.value = health;
    }
}
