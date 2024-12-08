using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFight : Fight
{
    public Transform target;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * 3 * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // »гнорируем вертикальную составл€ющую
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
