using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Castl : MonoBehaviour
{
    private int Health;

    public GameObject[] Tower;
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
        if (ui.Money - 10 > -1)
        {
            ui.Money = ui.Money - 10;
            ui.MoneyText.text = ui.Money.ToString();

            for (int i = 0; i < PositionPlatform.Length; i++)
            {
                if (PositionPlatform[i].Child == null)
                {
                    PositionPlatform[i].Child = Instantiate(SwordEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().ParentlatformPosition = PositionPlatform[i];
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().Enviroment = Enviroment;
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().spuwnEnemy = spuwnEnemy;
                    PositionPlatform[i].Child.GetComponent<Fight>().spuwnEnemy = spuwnEnemy;
                    break;
                }
            }
        }
    }
    public void SpuwnArrow()
    {
        if (ui.Money - 10 > -1)
        {
            ui.Money = ui.Money - 10;
            ui.MoneyText.text = ui.Money.ToString();

            for (int i = 0; i < PositionPlatform.Length; i++)
            {
                if (PositionPlatform[i].Child == null)
                {
                    PositionPlatform[i].Child = Instantiate(ArrowEnemy, PositionPlatform[i].transform.position, Quaternion.identity, PositionPlatform[i].transform);
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().ParentlatformPosition = PositionPlatform[i];
                    PositionPlatform[i].Child.GetComponent<Fight>().spuwnEnemy = spuwnEnemy;
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().Enviroment = Enviroment;
                    PositionPlatform[i].Child.GetComponent<EnemyPosition>().spuwnEnemy = spuwnEnemy;
                    break;
                }
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
            EventManager.DoEndGame();
        }
    }
    public void SpuwnTower() 
    {
        if (ui.Cristal - ui.tPrice > -1)
        {
            ui.Cristal = ui.Cristal - ui.tPrice;
            ui.CristalText.text = ui.Cristal.ToString();

            if (Tower[0].activeSelf == false)
            {
                Tower[0].SetActive(true);
                ui.Tower.text = 1.ToString();
                ui.tPrice = ui.tPrice + ui.tPriceAd;
                ui.tPriceText.text = ui.tPrice.ToString();
            }
            else if (Tower[1].activeSelf == false)
            {
                Tower[1].SetActive(true);
                ui.Tower.text = 2.ToString();
                Destroy(ui.TowerAd);
                ui.tPrice = 0;
                ui.tPriceText.text = "MAX";
            }
        }
    }
}
