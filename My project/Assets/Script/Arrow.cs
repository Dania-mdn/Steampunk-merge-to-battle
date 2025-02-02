using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Enemy
{
    private void Start()
    {
        enemyPosition = GetComponent<EnemyPosition>();
        enemyPosition.SwordOrArrow = 1;
        health = PlayerPrefs.GetInt("arrowHP");
        damage = PlayerPrefs.GetInt("arrowDamage");
        slider.maxValue = health;
        slider.value = health;
    }
}
