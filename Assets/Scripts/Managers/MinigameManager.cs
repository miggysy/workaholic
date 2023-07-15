using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : Singleton<MinigameManager>
{
    [SerializeField] private List<string> stressfulMinigames = new List<string>();
    [SerializeField] private List<string> relaxingMinigames = new List<string>();
    [SerializeField] private int stressfulMinigamesCompleted;
    private ScenesManager scenesManager;

    protected override void Awake()
    {
        base.Awake();
        scenesManager = FindObjectOfType<ScenesManager>();
    }
    public void LoadStressfulMinigame()
    {
        scenesManager.LoadScene(stressfulMinigames[stressfulMinigamesCompleted]);
    }
    public void LoadRelaxingMinigame()
    {
        scenesManager.LoadScene(relaxingMinigames[Random.Range(0, relaxingMinigames.Count)]);
    }

    private void CompleteStressfulMinigame()
    {
        stressfulMinigamesCompleted ++;
    }

    private void RestartDay()
    {
        stressfulMinigamesCompleted = 0;
    }

    private void OnEnable()
    {
        GameManager.onStartNewSession += RestartDay;
        GameManager.onDayFinished += RestartDay;
        GameManager.onSucceedLevel += CompleteStressfulMinigame;
        GameManager.onFailedLevel += CompleteStressfulMinigame;
    }

    private void OnDisable()
    {
        GameManager.onStartNewSession -= RestartDay;
        GameManager.onDayFinished -= RestartDay;
        GameManager.onSucceedLevel -= CompleteStressfulMinigame;
        GameManager.onFailedLevel -= CompleteStressfulMinigame;
    }

    public bool IsDayComplete()
    {
        return (stressfulMinigamesCompleted == stressfulMinigames.Count);
    }
}
