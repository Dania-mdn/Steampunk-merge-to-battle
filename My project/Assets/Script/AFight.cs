using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFight : Fight
{
    public Transform target;
    private Enemy enemy;
    private float speed;
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

        if (distance <= 3)
        {
            speed = 0;
            if (coldawn <= 0)
            {
                Contact(target.gameObject);
                coldawn = 1;
            }
            else
            {
                coldawn = coldawn - Time.deltaTime;
            }
        }
        else
        {
            speed = 3;
            coldawn = 0;
        }
    }

    private void Contact(GameObject collision)
    {
        if (collision.GetComponent<Bot>() != null)
        {
            collision.GetComponent<Bot>().hit(enemy.damage);
            coldawn = 2;
        }
        else if (collision.GetComponent<EnemyCastl>() != null)
        {
            collision.GetComponent<EnemyCastl>().HitCastl();
        }
    }
}
