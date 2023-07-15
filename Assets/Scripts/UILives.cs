using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UILives : MonoBehaviour
{
    [SerializeField] private List<CanvasGroup> lifeIcons = new List<CanvasGroup>();
    [SerializeField] private float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            lifeIcons.Add(child.gameObject.GetComponent<CanvasGroup>());
        }

        for(int i = 0; i < lifeIcons.Count - LivesManager.Instance.CurrentLives - 1; i++)
        {
            LeanTween.alphaCanvas(lifeIcons[i], 0.25f, 0f);
        }

        LoseLife();
    }

    private void LoseLife()
    {
        for(int i = 0; i < lifeIcons.Count - LivesManager.Instance.CurrentLives; i++)
        {
            LeanTween.alphaCanvas(lifeIcons[i], 0.25f, fadeTime);
        }
    }
}
