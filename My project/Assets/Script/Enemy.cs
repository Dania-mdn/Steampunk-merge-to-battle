using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    protected EnemyPosition enemyPosition;
    public int damage;
    public int health;
    public int lvl;
    public GameObject[] lvlMesh;
    public Slider slider;
    public TextMeshProUGUI hptxt;

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
        slider.maxValue = health;
        hptxt.text = slider.maxValue.ToString();
        slider.value = health;
    }
    public void hit(int damage)
    {
        if(health - damage > 0)
        {
            health = health - damage;
            slider.value = health;
            hptxt.text = slider.value.ToString();
        }
        else
        {
            EventManager.DoDestroy();
            lvlMesh[lvl].transform.parent = null;
            Destroy(gameObject);
        }
    }
}
