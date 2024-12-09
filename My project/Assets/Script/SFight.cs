using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFight : Fight
{
    public Transform target;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        for (int i = 0; i < spuwnEnemy.enemy.Length; i++)
        {
            if (spuwnEnemy.enemy[i] == null)
            {
                target = spuwnEnemy.enemy[i - 1].transform;
                break;
            }
        }

        transform.Translate(Vector3.forward * 3 * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // »гнорируем вертикальную составл€ющую
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if (collision.transform.tag == "EnemyCastl")
            {
                collision.transform.GetComponent<Enemy>().hit(enemy.damage);
            }
        }
    }
}
