using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField] private float timeToNextMinigame;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToNextMinigame());
    }

    private IEnumerator GoToNextMinigame()
    {
        yield return new WaitForSeconds(timeToNextMinigame);
        if(LivesManager.Instance.IsGameOver())
        {
            GameManager.onGameOver.Invoke();
        }
        else if(MinigameManager.Instance.IsDayComplete())
        {
            GameManager.onDayFinished?.Invoke();
        }
        else
        {
            MinigameManager.Instance.LoadStressfulMinigame();
        }
    }
}
