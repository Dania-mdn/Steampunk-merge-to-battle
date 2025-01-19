using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bot : MonoBehaviour
{
    public GameObject AnimationGO;
    public Transform target;
    public SpuwnEnemy spuwnEnemy;
    public int damage;
    public int health;
    public float speed;
    public int lvl;
    public GameObject[] lvlMesh;
    private float distance;
    private int j;
    private float coldawn;
    public Slider slider;
    public TextMeshProUGUI hptxt;

    private void Start()
    {
        AnimationGO.SetActive(false);
        distance = Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[0].transform.position);
        slider.maxValue = health;
        hptxt.text = slider.maxValue.ToString();
        slider.value = health;
    }

    private void Update()
    {
        for (int i = 0; i < spuwnEnemy.PlayerEnemy.Length; i++)
        {
            if (spuwnEnemy.PlayerEnemy[i] != null)
            {
                if (distance > Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[i].transform.position))
                {
                    distance = Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[i].transform.position);
                    j = i;
                }
                else
                {
                    distance = Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[0].transform.position);
                    j = i;
                }
            }
        }
        if (spuwnEnemy.PlayerEnemy[j] != null)
        {
            target = spuwnEnemy.PlayerEnemy[j].transform;
        }
        else
        {
            target = spuwnEnemy.PlayerEnemy[0].transform;
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
                Contact(target.gameObject);
                coldawn = 2;
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
    private void Contact(GameObject collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().hit(damage);
        }
        else if (collision.GetComponent<Castl>() != null)
        {
            collision.GetComponent<Castl>().HitCastl();
            Destroy(gameObject);
        }
    }

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
    public void hit(int damage)
    {
        if (health - damage > 0)
        {
            health = health - damage;
            slider.value = health;
            hptxt.text = slider.value.ToString();
        }
        else
        {
            AnimationGO.SetActive(true);
            AnimationGO.transform.parent = null;
            EventManager.DoAddMoney();
            Destroy();
        }
    }
    private void Destroy()
    {
        lvlMesh[lvl].transform.parent = null;
        Destroy(gameObject);
    }
}
