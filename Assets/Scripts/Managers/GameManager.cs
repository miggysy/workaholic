using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public delegate void GameEvent();
    public static GameEvent onSucceedLevel;
    public static GameEvent onFailedLevel;
    public static GameEvent onGameOver;
    private ScenesManager scenesManager;

    private void Awake()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
    }
}
