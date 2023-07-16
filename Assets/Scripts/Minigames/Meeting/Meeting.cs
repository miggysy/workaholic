using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meeting : MonoBehaviour
{
    [SerializeField] private List<ThoughtBubble> thoughtBubbles = new List<ThoughtBubble>();
    [SerializeField] private float[] thoughtBubbleLifetime;
    [Header("Spawn Duration")]
    [SerializeField] private float minDuration;
    [SerializeField] private float maxDuration;
    private bool justStarted;

    // Start is called before the first frame update
    void Start()
    {
        justStarted = true;
        foreach(ThoughtBubble thoughtBubble in thoughtBubbles)
        {
            SpawnThoughtBubble(thoughtBubble);
        }
        justStarted = false;
    }

    public void SpawnThoughtBubble(ThoughtBubble thoughtBubble)
    {
        StartCoroutine(SpawnThoughtBubbleCoroutine(thoughtBubble, Random.Range(justStarted ? 0.1f : minDuration, justStarted ? maxDuration - minDuration - 0.1f : maxDuration)));
    }

    private IEnumerator SpawnThoughtBubbleCoroutine(ThoughtBubble thoughtBubble, float delay)
    {
        yield return new WaitForSeconds(delay);
        thoughtBubble.Duration = thoughtBubbleLifetime[GameManager.Instance.Day <= thoughtBubbleLifetime.Length ? GameManager.Instance.Day - 1 : thoughtBubbleLifetime.Length - 1];
        thoughtBubble.gameObject.SetActive(true);
    }
}
