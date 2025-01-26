using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI lvlTitle;
    private int lvl;
    public int loosePrizecoef = 15;
    private int Prize;
    private int coef;
    public TextMeshProUGUI LoosForCoef;
    public TextMeshProUGUI WinForCoef;
    public TextMeshProUGUI loosePrizeText;
    public TextMeshProUGUI WinnPrizeText;
    public GameObject tablo;
    public GameObject tablo2;
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
        EventManager.addMoney += AddMoney;
    }
    private void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.EndGame -= SetLoose;
        EventManager.WeenGame -= SetWeen;
        EventManager.addMoney -= AddMoney;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("CristalForLVL"))
        {
            Cristal = PlayerPrefs.GetInt("Cristal") + PlayerPrefs.GetInt("CristalForLVL");
            PlayerPrefs.DeleteKey("CristalForLVL"); 
            PlayerPrefs.SetInt("Cristal", Cristal);
        }
        else
        {
            Cristal = PlayerPrefs.GetInt("Cristal");
        }
        
        SliderIncome.maxValue = Coldawn;
        IncomeCountTxt.text = IncomeCount.ToString() + "C";
        IncomeCountTxtButton.text = IncomeCountAdd.ToString();
        SwordHP.text = swordHP.ToString();
        ArrowHP.text = arrowHP.ToString();
        ArrowDamage.text = arrowDamage.ToString();
        SwordDamage.text = swordDamage.ToString();
        PlayerPrefs.SetInt("swordHP", swordHP);
        PlayerPrefs.SetInt("swordDamage", swordDamage);
        PlayerPrefs.SetInt("arrowHP", arrowHP);
        PlayerPrefs.SetInt("arrowDamage", arrowDamage);

        CristalText.text = Cristal.ToString() + "C";
        tPriceText.text = tPrice.ToString() + "C";
        iPriceText.text = iPrice.ToString() + "C";
        hPriceText.text = hPrice.ToString() + "C";
        sPriceText.text = sPrice.ToString() + "C";
        aPriceText.text = aPrice.ToString() + "C";

        if (PlayerPrefs.HasKey("lvl"))
        {
            lvl = PlayerPrefs.GetInt("lvl");
        }
        else
        {
            lvl = 1;
        }

        lvlTitle.text = "LVL" + lvl.ToString();
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
            IncomeCountTxt.text = IncomeCount.ToString() + "C";
        }
        SliderIncome.value = time;

        tablo.transform.Rotate(0, 0, -200 * Time.deltaTime);
        tablo2.transform.Rotate(0, 0, -200 * Time.deltaTime);

        float currentZRotation = tablo.transform.eulerAngles.z;
        if (currentZRotation < 360 && currentZRotation > 300)
        {
            coef = 3;
        }
        else if (currentZRotation < 300 && currentZRotation > 240)
        {
            coef = 2;
        }
        else if (currentZRotation < 240 && currentZRotation > 180)
        {
            coef = 1;
        }
        else if (currentZRotation < 180 && currentZRotation > 120)
        {
            coef = 3;
        }
        else if (currentZRotation < 120 && currentZRotation > 60)
        {
            coef = 2;
        }
        else if (currentZRotation < 60 && currentZRotation > 0)
        {
            coef = 1;
        }

        WinForCoef.text = (Prize * coef).ToString();
        LoosForCoef.text = (Prize * coef).ToString();
    }
    public void AddIncome()
    {
        if (Cristal - iPrice > -1)
        {
            Cristal = Cristal - iPrice;
            CristalText.text = Cristal.ToString() + "C";
            IncomeCountAdd = IncomeCountAdd + 5;
            IncomeCountTxtButton.text = IncomeCountAdd.ToString();
            iPrice = iPrice + iPriceAd;
            iPriceText.text = iPrice.ToString() + "C";
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
            CristalText.text = Cristal.ToString() + "C";
            healthCastl = healthCastl + health;
            healthCastltxt.text = healthCastl.ToString();
            healthCastltxtButton.text = healthCastl.ToString();
            hPrice = hPrice + hPriceAd;
            hPriceText.text = hPrice.ToString() + "C";
        }
    }
    public void AddCrystalWinn()
    {
        Cristal = Cristal + Prize;
        CristalText.text = Cristal.ToString() + "C";

        IncomeCount = 0;
        IncomeCountTxt.text = IncomeCount.ToString() + "C";
    }
    public void AddCrystalLoose()
    {
        Cristal = Cristal + Prize;
        CristalText.text = Cristal.ToString() + "C";

        IncomeCount = 0;
        IncomeCountTxt.text = IncomeCount.ToString() + "C";
    }
    public void UpSword()
    {
        if (Cristal - sPrice > -1)
        {
            Cristal = Cristal - sPrice;
            CristalText.text = Cristal.ToString() + "C";

            swordHP = swordHP + 10;
            PlayerPrefs.SetInt("swordHP", swordHP);
            SwordHP.text = swordHP.ToString();

            swordDamage = swordDamage + 3;
            PlayerPrefs.SetInt("swordDamage", swordDamage);
            SwordDamage.text = swordDamage.ToString();

            sPrice = sPrice + sPriceAd;
            sPriceText.text = sPrice.ToString() + "C";
        }
    }
    public void UpArrow()
    {
        if (Cristal - aPrice > -1)
        {
            Cristal = Cristal - aPrice;
            CristalText.text = Cristal.ToString() + "C";

            arrowHP = arrowHP + 8;
            PlayerPrefs.SetInt("arrowHP", arrowHP);
            ArrowHP.text = arrowHP.ToString();

            arrowDamage = arrowDamage + 4;
            PlayerPrefs.SetInt("arrowDamage", arrowDamage);
            ArrowDamage.text = arrowDamage.ToString();

            aPrice = aPrice + aPriceAd;
            aPriceText.text = aPrice.ToString() + "C";
        }
    }
    public void AddCrystal()
    {
        Cristal = Cristal + IncomeCount;
        CristalText.text = Cristal.ToString() + "C";

        IncomeCount = 0;
        IncomeCountTxt.text = IncomeCount.ToString() + "C";
    }
    public void AddMoney()
    {
        Invoke("AddMoneyforBot", 2);
    }
    public void AddMoneyforBot()
    {
        StartCoroutine(AdMoney());
    }
    IEnumerator AdMoney()
    {
        int money = 0;
        while (money < 10)
        {
            Money += 1;
            money += 1;
            MoneyText.text = Money.ToString();

            yield return new WaitForSeconds(0.1f);
        }
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SetWeen()
    {
        Ween.SetActive(true);
        Enemy.SetActive(false);
        Prize = (loosePrizecoef * 2) + lvl;
        WinnPrizeText.text = Prize.ToString() + "C";
        lvl++; 
        PlayerPrefs.SetInt("lvl", lvl);
    }
    public void SetLoose()
    {
        Loose.SetActive(true);
        Enemy.SetActive(false);
        Prize = loosePrizecoef + lvl;
        loosePrizeText.text = Prize.ToString() + "C";
    }
    public void NoThanks()
    {
        PlayerPrefs.SetInt("CristalForLVL", Prize * coef);
        SceneManager.LoadScene(0);
    }
    public void TakeBonus()
    {
        PlayerPrefs.SetInt("CristalForLVL", Prize * coef);
        SceneManager.LoadScene(0);
    }
}
