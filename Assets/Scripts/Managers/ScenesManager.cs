using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private string successScreen;
    [SerializeField] private string failScreen;
    [SerializeField] private string gameOverScreen;
    [SerializeField] private string transitionScreen;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void LoadSuccessScreen()
    {
        SceneManager.LoadScene(successScreen);
    }

    private void LoadFailScreen()
    {
        SceneManager.LoadScene(failScreen);
    }

    private void LoadGameOverScreen()
    {
        SceneManager.LoadScene(gameOverScreen);
    }

    private void LoadTransitionScreen()
    {
        SceneManager.LoadScene(transitionScreen);
    }

    public void StartGame()
    {
        GameManager.onStartNewSession?.Invoke();
        LoadTransitionScreen();
    }

    public void ExitApplication()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    private void OnEnable()
    {
        GameManager.onSucceedLevel += LoadSuccessScreen;
        GameManager.onFailedLevel += LoadFailScreen;
        GameManager.onGameOver += LoadGameOverScreen;
        GameManager.onDayFinished += LoadTransitionScreen;
    }

    private void OnDisable()
    {
        GameManager.onSucceedLevel -= LoadSuccessScreen;
        GameManager.onFailedLevel -= LoadFailScreen;
        GameManager.onGameOver -= LoadGameOverScreen;
        GameManager.onDayFinished -= LoadTransitionScreen;
    }
}
