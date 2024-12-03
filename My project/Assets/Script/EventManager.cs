using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action StartGame;
    public static event Action EndGame;
    public static void DoStartGame()
    {
        StartGame?.Invoke();
    }
    public static void DoEndGame()
    {
        EndGame?.Invoke();
    }
}
