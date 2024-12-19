using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Castl : MonoBehaviour
{
    private int Health;

    public GameObject Enviroment;
    public GameObject Platforma;
    public SpuwnEnemy spuwnEnemy;

    public PlatformPosition[] PositionPlatform;
    public GameObject SwordEnemy;
    public GameObject ArrowEnemy;

    private RaycastHit hit;
    private GameObject Mediate;
    private Ray ray;

    public UI ui;

    private void Start()
    {
        Platforma.SetActive(false);
    }
    public void StartGame()
    {
        Health = ui.healthCastl;
        Platforma.SetActive(true);
        EventManager.DoStartGame();
        spuwnEnemy.startGame = true;
    }
    public void SpuwnSword()
    {
        for (int i = 0; i < PositionPlatform.Length; i++)
        {
            if (PositionPlatform[i].Child == null)
            {
                PositionPlatform[i].Child = Instantiate(SwordEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                PositionPlatform[i].Child.GetComponent<EnemyPosition>().ParentlatformPosition = PositionPlatform[i];
                PositionPlatform[i].Child.GetComponent<EnemyPosition>().Enviroment = Enviroment;
                PositionPlatform[i].Child.GetComponent<Fight>().spuwnEnemy = spuwnEnemy;
                spuwnEnemy.AddPlayerEnemy(PositionPlatform[i].Child);
                break;
            }
        }
    }
    public void SpuwnArrow()
    {
        for (int i = 0; i < PositionPlatform.Length; i++)
        {
            if (PositionPlatform[i].Child == null)
            {
                PositionPlatform[i].Child = Instantiate(ArrowEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                PositionPlatform[i].Child.GetComponent<EnemyPosition>().ParentlatformPosition = PositionPlatform[i];
                PositionPlatform[i].Child.GetComponent<Fight>().spuwnEnemy = spuwnEnemy;
                PositionPlatform[i].Child.GetComponent<EnemyPosition>().Enviroment = Enviroment;
                spuwnEnemy.AddPlayerEnemy(PositionPlatform[i].Child);
                break;
            }
        }
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (Mediate != null)
            Mediate.transform.position = hit.point + Mediate.transform.up / 5;
    }
    public void PointerDown()
    {
        if(hit.transform.gameObject != null)
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Mediate = hit.transform.gameObject;
                Mediate.GetComponent<EnemyPosition>().Take();
                EventManager.DooffRaycastColission(2);
            }
        }
    }
    public void PointerUp()
    {
        if (hit.transform.gameObject.tag != "Enemy")
        {
            if(Mediate != null)
            {
            Mediate.GetComponent<EnemyPosition>().Fixed();
            Mediate = null;
            EventManager.DooffRaycastColission(6);
            }
        }
    }
    public void HitCastl()
    {
        if (Health - 1 > 0)
        {
            Health = Health - 1;
            ui.SetHealth(1);
        }
        else
        {

        }
    }
}
