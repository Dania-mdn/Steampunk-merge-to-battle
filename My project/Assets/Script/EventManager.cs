using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action<int> offRaycastColission;
    public static event Action StartGame;
    public static event Action EndGame;
    public static event Action WeenGame;
    public static void DooffRaycastColission(int layer)
    {
        offRaycastColission?.Invoke(layer);
    }
    public static void DoStartGame()
    {
        StartGame?.Invoke();
    }
    public static void DoEndGame()
    {
        EndGame?.Invoke();
    }
    public static void DoWeenGame()
    {
        WeenGame?.Invoke();
    }
}
