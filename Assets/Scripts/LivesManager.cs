using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : Singleton<LivesManager>
{
    [SerializeField] private int maxLives;
    [SerializeField] private int currentLives;
    public int CurrentLives { get => currentLives; }
    private void ResetLives()
    {
        currentLives = maxLives;
    }
    
    private void LoseLife()
    {
        currentLives--;
    }

    public bool IsGameOver()
    {
        return currentLives <= 0;
    }

    private void OnEnable()
    {
        GameManager.onStartNewSession += ResetLives;
        GameManager.onFailedLevel += LoseLife;
    }

    private void OnDisable()
    {
        GameManager.onStartNewSession -= ResetLives;
        GameManager.onFailedLevel -= LoseLife;
    }
}
