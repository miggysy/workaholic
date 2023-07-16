using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void PressDown()
    {
        animator.SetTrigger("PressDown");
    }

    private void PressUp()
    {
        animator.SetTrigger("PressUp");
    }

    private void OnEnable()
    {
        DoWork.onPressDown += PressDown;
        DoWork.onPressUp += PressUp;
    }

    private void OnDisable()
    {
        DoWork.onPressDown -= PressDown;
        DoWork.onPressUp -= PressUp;
    }
}
