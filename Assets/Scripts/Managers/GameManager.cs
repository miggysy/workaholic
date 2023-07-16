using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Manager")]
    [SerializeField] private int day;
    public int Day { get => day; }
    public delegate void GameEvent();
    public static GameEvent onStartNewSession;
    public static GameEvent onDayFinished;
    public static GameEvent onSucceedLevel;
    public static GameEvent onFailedLevel;
    public static GameEvent onGameOver;

    protected override void Awake()
    {
        base.Awake();
    }

    private void GainScore() => day++;
    private void ResetScore() => day = 1;

    private void OnEnable()
    {
        onStartNewSession += ResetScore;
        onDayFinished += GainScore; 
    }

    private void OnDisable()
    {
        onStartNewSession -= ResetScore;
        onDayFinished -= GainScore;
    }
}
