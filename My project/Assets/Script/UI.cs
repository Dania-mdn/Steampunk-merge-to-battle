using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public int Cristal;
    public TextMeshProUGUI CristalText;
    public int Money;
    public TextMeshProUGUI MoneyText;

    public GameObject Enemy;
    public GameObject Ween;
    public GameObject Loose;
    public GameObject StartMenu;
    public CinemachineVirtualCamera CinemachineVirtualCamera;

    //Health
    public GameObject Health;
    public int healthCastl;
    public TextMeshProUGUI healthCastltxt;
    public TextMeshProUGUI healthCastltxtButton;
    public int hPrice;
    public int hPriceAd;
    public TextMeshProUGUI hPriceText;

    //Income
    public int IncomeCount;
    public int IncomeCountAdd;
    public TextMeshProUGUI IncomeCountTxt;
    public TextMeshProUGUI IncomeCountTxtButton;
    public Slider SliderIncome;
    private float time;
    private int Coldawn = 30;
    public int iPrice;
    public int iPriceAd;
    public TextMeshProUGUI iPriceText;

    //tower
    public TextMeshProUGUI Tower;
    public TextMeshProUGUI TowerAd;
    public int tPrice;
    public int tPriceAd;
    public TextMeshProUGUI tPriceText;

    //sword
    private int swordHP = 10;
    public TextMeshProUGUI SwordHP;
    private int swordDamage = 3;
    public TextMeshProUGUI SwordDamage;
    public int sPrice;
    public int sPriceAd;
    public TextMeshProUGUI sPriceText;

    //arrow
    private int arrowHP = 8;
    public TextMeshProUGUI ArrowHP;
    private int arrowDamage = 4;
    public TextMeshProUGUI ArrowDamage;
    public int aPrice;
    public int aPriceAd;
    public TextMeshProUGUI aPriceText;

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

        CristalText.text = Cristal.ToString();
        tPriceText.text = tPrice.ToString();
        iPriceText.text = iPrice.ToString();
        hPriceText.text = hPrice.ToString();
        sPriceText.text = sPrice.ToString();
        aPriceText.text = aPrice.ToString();
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
        if (Cristal - iPrice > -1)
        {
            Cristal = Cristal - iPrice;
            CristalText.text = Cristal.ToString();
            IncomeCountAdd = IncomeCountAdd + 5;
            IncomeCountTxtButton.text = IncomeCountAdd.ToString();
            iPrice = iPrice + iPriceAd;
            iPriceText.text = iPrice.ToString();
        }
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
        if(Cristal - hPrice > -1)
        {
            Cristal = Cristal - hPrice;
            CristalText.text = Cristal.ToString();
            healthCastl = healthCastl + health;
            healthCastltxt.text = healthCastl.ToString();
            healthCastltxtButton.text = healthCastl.ToString();
            hPrice = hPrice + hPriceAd;
            hPriceText.text = hPrice.ToString();
        }
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
        if (Cristal - sPrice > -1)
        {
            Cristal = Cristal - sPrice;
            CristalText.text = Cristal.ToString();

            swordHP = swordHP + 10;
            PlayerPrefs.SetInt("swordHP", swordHP);
            SwordHP.text = swordHP.ToString();

            swordDamage = swordDamage + 3;
            PlayerPrefs.SetInt("swordDamage", swordDamage);
            SwordDamage.text = swordDamage.ToString();

            sPrice = sPrice + sPriceAd;
            sPriceText.text = sPrice.ToString();
        }
    }
    public void UpArrow()
    {
        if (Cristal - aPrice > -1)
        {
            Cristal = Cristal - aPrice;
            CristalText.text = Cristal.ToString();

            arrowHP = arrowHP + 8;
            PlayerPrefs.SetInt("arrowHP", arrowHP);
            ArrowHP.text = arrowHP.ToString();

            arrowDamage = arrowDamage + 4;
            PlayerPrefs.SetInt("arrowDamage", arrowDamage);
            ArrowDamage.text = arrowDamage.ToString();

            aPrice = aPrice + aPriceAd;
            aPriceText.text = aPrice.ToString();
        }
    }
    public void AddCrystal()
    {
        Cristal = Cristal + IncomeCount;
        CristalText.text = Cristal.ToString();

        IncomeCount = 0;
        IncomeCountTxt.text = IncomeCount.ToString();
    }
}
