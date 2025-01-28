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
        if (spuwnEnemy.PlayerEnemy[1] != null)
        {
            distance = Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[1].transform.position);
            target = spuwnEnemy.PlayerEnemy[1].transform;
        }
        else
        {
            distance = Vector3.Distance(transform.position, spuwnEnemy.PlayerEnemy[0].transform.position);
            target = spuwnEnemy.PlayerEnemy[0].transform;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // »гнорируем вертикальную составл€ющую
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if (distance <= 1)
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
            EventManager.DoDestroyEnemy();
            Destroy();
        }
    }
    private void Destroy()
    {
        lvlMesh[lvl].transform.parent = null;
        Destroy(gameObject);
    }
}
