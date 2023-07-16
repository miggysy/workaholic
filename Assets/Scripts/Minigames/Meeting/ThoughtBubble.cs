using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThoughtBubble : MonoBehaviour
{
    private float duration;
    public float Duration { get => duration; set => duration = value; }
    private bool playerPopped;
    private Meeting meeting;

    private void Awake()
    {
        meeting = FindObjectOfType<Meeting>();
    }

    private void OnEnable()
    {
        playerPopped = false;
        StartCoroutine(ThoughtBubbleCountdown());
    }

    private IEnumerator ThoughtBubbleCountdown()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            PopBubble();
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(ThoughtBubbleCountdown());
    }
    
    private void PopBubble()
    {
        //Play animation

        if(!playerPopped)
        {
            //Game over
            GameManager.onFailedLevel?.Invoke();
        }

        GetComponent<Animator>().SetTrigger("Popped");
        
        //Disable game object
        Invoke("DisableObject", 0.25f);
        
    }

    private void DisableObject()
    {
        meeting.SpawnThoughtBubble(this);
        gameObject.SetActive(false);
    }

    public void PlayerPopBubble()
    {
        playerPopped = true;
        PopBubble();
    }
}
