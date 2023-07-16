using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubbleEffect : MonoBehaviour
{
    [SerializeField][Range(0f,1f)] private float durationThreshold;
    private float maxDuration;
    private Animation anim;
    private ThoughtBubble thoughtBubble;
    void Awake()
    {
        anim = GetComponent<Animation>();
        thoughtBubble = GetComponent<ThoughtBubble>();
    }

    private void OnEnable()
    {
        maxDuration = thoughtBubble.Duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.isPlaying) return;
        if(thoughtBubble.Duration <= maxDuration * durationThreshold) anim.Play();
    }

    private void OnDisable()
    {
        anim.Rewind();
        anim.Play();
        anim.Sample();
        anim.Stop();
    }
}
