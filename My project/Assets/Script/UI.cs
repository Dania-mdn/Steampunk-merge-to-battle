using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
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
}
