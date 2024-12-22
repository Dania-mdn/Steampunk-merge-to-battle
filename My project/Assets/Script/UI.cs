using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public int healthCastl;
    public TextMeshProUGUI healthCastltxt;
    public TextMeshProUGUI healthCastltxtButton;
    public GameObject Health;
    public GameObject Enemy;
    public GameObject Ween;
    public GameObject Loose;
    public GameObject StartMenu;
    public CinemachineVirtualCamera CinemachineVirtualCamera;

    public int IncomeCount;
    public int IncomeCountAdd;
    public TextMeshProUGUI IncomeCountTxt;
    public TextMeshProUGUI IncomeCountTxtButton;
    public Slider SliderIncome;
    private float time;
    private int Coldawn = 30;

    public TextMeshProUGUI Tower;
    public TextMeshProUGUI TowerAd;

    private int swordHP = 10;
    public TextMeshProUGUI SwordHP;
    private int swordDamage = 3;
    public TextMeshProUGUI SwordDamage;
    private int arrowHP = 8;
    public TextMeshProUGUI ArrowHP;
    private int arrowDamage = 4;
    public TextMeshProUGUI ArrowDamage;

    private void OnEnable()
    {
        EventManager.StartGame += StartGame;
        EventManager.EndGame += SetLoose;
        EventManager.WeenGame += SetWeen;
    }
    private void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.EndGame += SetLoose;
        EventManager.WeenGame += SetWeen;
    }
    private void Start()
    {
        SliderIncome.maxValue = Coldawn;
        IncomeCountTxt.text = IncomeCount.ToString();
        IncomeCountTxtButton.text = IncomeCountAdd.ToString();
        SwordHP.text = swordHP.ToString();
        ArrowHP.text = arrowHP.ToString();
        ArrowDamage.text = arrowDamage.ToString();
        SwordDamage.text = swordDamage.ToString();
        PlayerPrefs.SetInt("swordHP", swordHP);
        PlayerPrefs.SetInt("swordDamage", swordDamage);
        PlayerPrefs.SetInt("arrowHP", arrowHP);
        PlayerPrefs.SetInt("arrowDamage", arrowDamage);
    }
    private void Update()
    {
        if(time < Coldawn)
        {
            time = time + Time.deltaTime;
        }
        else
        {
            time = 0;
            IncomeCount = IncomeCount + IncomeCountAdd;
            IncomeCountTxt.text = IncomeCount.ToString();
        }
        SliderIncome.value = time;
    }
    public void AddIncome()
    {
        IncomeCountAdd = IncomeCountAdd + 5;
        IncomeCountTxtButton.text = IncomeCountAdd.ToString();
    }
    private void StartGame()
    {
        CinemachineVirtualCamera.Priority = 2;
    }
    public void SetHealth(int health)
    {
        healthCastl = healthCastl - health;
        healthCastltxt.text = healthCastl.ToString();
    }
    public void AddHealth(int health)
    {
        healthCastl = healthCastl + health;
        healthCastltxt.text = healthCastl.ToString();
        healthCastltxtButton.text = healthCastl.ToString();
    }
    public void SetWeen()
    {
        Ween.SetActive(true);
        Enemy.SetActive(false);
    }
    public void SetLoose()
    {
        Loose.SetActive(true);
        Enemy.SetActive(false);
    }
    public void UpSword()
    {
        swordHP = swordHP + 10;
        PlayerPrefs.SetInt("swordHP", swordHP);
        SwordHP.text = swordHP.ToString();

        swordDamage = swordDamage + 3;
        PlayerPrefs.SetInt("swordDamage", swordDamage);
        SwordDamage.text = swordDamage.ToString();
    }
    public void UpArrow()
    {
        arrowHP = arrowHP + 8;
        PlayerPrefs.SetInt("arrowHP", arrowHP);
        ArrowHP.text = arrowHP.ToString();

        arrowDamage = arrowDamage + 4;
        PlayerPrefs.SetInt("arrowDamage", arrowDamage);
        ArrowDamage.text = arrowDamage.ToString();
    }
}
