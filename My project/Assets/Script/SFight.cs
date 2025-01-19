using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFight : Fight
{
    public Transform target;
    private Enemy enemy;
    public float speed;
    private float coldawn;
    private float distance;
    private int j;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[0].transform.position);
    }

    private void Update()
    {
        for (int i = 1; i < spuwnEnemy.enemy.Length; i++)
        {
            if (spuwnEnemy.enemy[i] != null)
            {
                distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[i].transform.position);
                j = i;
                break;
            }
        }
        if (spuwnEnemy.enemy[j] != null)
        {
            target = spuwnEnemy.enemy[j].transform;
        }
        else
        {
            target = spuwnEnemy.enemy[0].transform; 
            distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[0].transform.position);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // »гнорируем вертикальную составл€ющую
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if (distance <= 0.5f)
        {
            speed = 0;
            if (coldawn <= 0)
            {
                Contact();
                coldawn = 1;
            }
            else
            {
                coldawn = coldawn - Time.deltaTime;
            }
        }
        else
        {
            if (speed == 0)
            {
                Invoke("SetSpeed", 0.5f);
            }
            coldawn = 0;
        }
    }

    private void SetSpeed()
    {
        speed = 2;
    }
    private void Contact()
    {
        if (target.gameObject.GetComponent<Bot>() != null)
        {
            target.gameObject.GetComponent<Bot>().hit(enemy.damage);
            coldawn = 2;
        }
        else if (target.gameObject.GetComponent<EnemyCastl>() != null)
        {
            target.gameObject.GetComponent<EnemyCastl>().HitCastl();
        }
    }
}
