using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected EnemyPosition enemyPosition;
    public int damage;
    public int health;
    public int lvl;
    public GameObject[] lvlMesh;

    public void SetNewLvL()
    {
        lvl++;
        for (int i = 0; i < lvlMesh.Length; i++)
        {
            if (lvl == i)
            {
                lvlMesh[i].SetActive(true);
            }
            else
            {
                lvlMesh[i].SetActive(false);
            }
        }
        damage = damage * 2;
        health = health * 2;
    }
    public void setActive()
    {

    }
}
