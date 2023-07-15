using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoWork : MonoBehaviour
{
    public static event Action onPressDown;
    public static event Action onPressUp;
    [SerializeField] private int tapsRequired;
    public int TapsRequired { get => tapsRequired; set => tapsRequired = value; }
    [SerializeField] private int currentTaps;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize currentTaps
        currentTaps = 0;
    }

    private void OnPressDown()
    {
        onPressDown?.Invoke();
    }

    private void OnPressUp()
    {
        onPressUp?.Invoke();
    }

    private void AddTap()
    {
        currentTaps++;
        if(currentTaps == tapsRequired)
        {
            //Minigame Succeeded
            GameManager.onSucceedLevel?.Invoke();
        }
    }

    private void OnEnable() 
    {
        onPressUp += AddTap;
    }

    private void OnDisable()
    {
        onPressUp -= AddTap;
    }
}
