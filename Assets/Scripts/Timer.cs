using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float[] time;
    [SerializeField] private float currentTime;
    [SerializeField] private Image timerImg;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        if(gameManager.Day < time.Length) currentTime = time[gameManager.Day];
        else currentTime = time[time.Length-1] / 2; 
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForEndOfFrame();

        currentTime -= Time.deltaTime;

        if(gameManager.Day < time.Length)
            timerImg.fillAmount -= Time.deltaTime / time[gameManager.Day];
        else
            timerImg.fillAmount -= Time.deltaTime / (time[time.Length-1] * 0.75f);

        if(timerImg.fillAmount <= 0)
        {
            //Minigame failed
            GameManager.onFailedLevel?.Invoke();
        }
        else
        {
            StartCoroutine(StartTimer());
        }   
    }
}
