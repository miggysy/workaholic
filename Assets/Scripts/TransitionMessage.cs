using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionMessage : MonoBehaviour
{
    private TextMeshProUGUI transitionMsgTxt;
    [SerializeField] private bool success;
    [SerializeField] private string[] transitionMessages;
    
    void Awake()
    {
        transitionMsgTxt = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if(success) transitionMsgTxt.text = transitionMessages[Random.Range(0, transitionMessages.Length)];
        else transitionMsgTxt.text = transitionMessages[LivesManager.Instance.CurrentLives];
    }
}
