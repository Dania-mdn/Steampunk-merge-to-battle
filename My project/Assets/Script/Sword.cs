using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 0;
        health = PlayerPrefs.GetInt("arrowHP");
        damage = PlayerPrefs.GetInt("arrowDamage");
        slider.maxValue = health;
        slider.value = health;
    }
}
