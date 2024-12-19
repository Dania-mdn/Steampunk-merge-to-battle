using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public int healthCastl;
    public TextMeshProUGUI healthCastltxt;
    public GameObject Health;
    public GameObject StartMenu;
    public CinemachineVirtualCamera CinemachineVirtualCamera;

    private void OnEnable()
    {
        EventManager.StartGame += StartGame;
    }
    private void OnDisable()
    {
        EventManager.StartGame -= StartGame;
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
}
