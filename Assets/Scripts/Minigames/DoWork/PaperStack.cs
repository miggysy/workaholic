using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStack : MonoBehaviour
{
    [SerializeField] private Transform paperStack1, paperStack2;
    private DoWork doWork;
    private float scaleToAdd;
    private int numTapsRequired;
    private int currentNumTaps;

    void Awake()
    {
        doWork = FindObjectOfType<DoWork>();
    }
    // Start is called before the first frame update
    void Start()
    {
        numTapsRequired = doWork.TapsRequired;
        if(numTapsRequired <= 10)
        {
            paperStack2.gameObject.SetActive(false);
            scaleToAdd = paperStack1.localScale.y / numTapsRequired;
            paperStack1.localScale =  new Vector3(paperStack1.localScale.x, 0, paperStack1.localScale.z);
        }
        else
        {
            scaleToAdd = paperStack1.localScale.y / numTapsRequired / 2;
            paperStack1.localScale = new Vector3(paperStack1.localScale.x, 0, paperStack1.localScale.z);
            paperStack2.localScale = new Vector3(paperStack2.localScale.x, 0, paperStack2.localScale.z);
        }
    }

    private void AddPaper()
    {
        if(numTapsRequired <= 10)
        {
            paperStack1.localScale += new Vector3(0, scaleToAdd, 0);
        }
        else
        {
            if(currentNumTaps < numTapsRequired / 2) paperStack1.localScale += new Vector3(0, scaleToAdd, 0);
            else paperStack2.localScale += new Vector3(0, scaleToAdd, 0);
        }
    }

    private void OnEnable()
    {
        DoWork.onPressUp += AddPaper;
    }

    private void OnDisable()
    {
        DoWork.onPressUp -= AddPaper;
    }

}
