using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpuwnEnemy : MonoBehaviour
{
    public GameObject EnemyCastl;
    public GameObject PlayerCastl;
    public GameObject prefabSword;
    public GameObject positionSpuwn;
    public GameObject[] enemy;
    public GameObject[] PlayerEnemy;

    private float time;
    public float culdawn;
    public bool startGame = false;

    private void Start()
    {
        enemy = new GameObject[50];
        enemy[0] = EnemyCastl;
        PlayerEnemy = new GameObject[50];
        PlayerEnemy[0] = PlayerCastl;
        time = culdawn;
    }
    public void AddPlayerEnemy(GameObject playerEnemy)
    {
        for (int i = 0; i < PlayerEnemy.Length; i++)
        {
            if (PlayerEnemy[i] == null)
            {
                PlayerEnemy[i] = playerEnemy;
                break;
            }
        }
    }

    private void Update()
    {
        if (!startGame) return;

        if(time <= 0)
        {
            SpuwnSword();
            time = culdawn;
        }
        else
        {
            time = time - Time.deltaTime;
        }
    }

    public void SpuwnSword()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i] == null)
            {
                enemy[i] = Instantiate(prefabSword, positionSpuwn.transform.position, Quaternion.identity, gameObject.transform);
                enemy[i].GetComponent<Bot>().spuwnEnemy = this;
                break;
            }
        }
    }
}
