using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuwnEnemy : MonoBehaviour
{
    public GameObject EnemyCastl;
    public GameObject prefabSword;
    public GameObject positionSpuwn;
    public GameObject[] enemy;

    private void Start()
    {
        enemy = new GameObject[20];
        enemy[0] = EnemyCastl;
        SpuwnSword();
    }
    public void SpuwnSword()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] == null)
            {
                enemy[i] = Instantiate(prefabSword, positionSpuwn.transform.position, Quaternion.identity, gameObject.transform);
                break;
            }
        }
    }
}
