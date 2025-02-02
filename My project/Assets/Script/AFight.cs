using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFight : Fight
{
    public Transform target;
    private Enemy enemy;
    public float speed;
    private float coldawn;
    private float distance;
    private Animation Gun;

    private void Start()
    {
        Gun = GetComponent<Animation>();
        enemy = GetComponent<Enemy>();
        distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[0].transform.position);
    }

    private void Update()
    {
        if (spuwnEnemy.enemy[1] != null)
        {
            target = spuwnEnemy.enemy[1].transform;
            distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[1].transform.position);
        }
        else
        {
            target = spuwnEnemy.enemy[0].transform;
            distance = Vector3.Distance(transform.position, spuwnEnemy.enemy[0].transform.position);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // ���������� ������������ ������������
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if (distance <= 4)
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
            speed = 2;
            coldawn = 0;
        }
    }

    private void Contact(GameObject collision)
    {
        if (collision.GetComponent<Bot>() != null)
        {
            //Gun.Play();
            collision.GetComponent<Bot>().hit(enemy.damage);
            coldawn = 2;
        }
        else if (collision.GetComponent<EnemyCastl>() != null)
        {
            collision.GetComponent<EnemyCastl>().HitCastl();
        }
    }
}
