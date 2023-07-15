using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private List<string> stressfulMinigames = new List<string>();
    [SerializeField] private List<string> relaxingMinigames = new List<string>();
    private ScenesManager scenesManager;

    private void Awake()
    {
        scenesManager = FindObjectOfType<ScenesManager>();
    }
    public void LoadRandomStressfulMinigame()
    {
        scenesManager.LoadScene(stressfulMinigames[Random.Range(0, stressfulMinigames.Count)]);
    }
    public void LoadRandomRelaxingMinigame()
    {
        scenesManager.LoadScene(relaxingMinigames[Random.Range(0, relaxingMinigames.Count)]);
    }
}
