using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubbleEffect : MonoBehaviour
{
    [SerializeField][Range(0f,1f)] private float durationThreshold;
    private float maxDuration;
    private Animator anim;
    private ThoughtBubble thoughtBubble;
    void Awake()
    {
        anim = GetComponent<Animator>();
        thoughtBubble = GetComponent<ThoughtBubble>();
    }

    private void OnEnable()
    {
        maxDuration = thoughtBubble.Duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("ThoughtBubbleShake")) return;
        if(thoughtBubble.Duration <= maxDuration * durationThreshold) anim.SetTrigger("Warning");
    }
}
