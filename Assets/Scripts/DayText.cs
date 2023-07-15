using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayText : MonoBehaviour
{
    private TextMeshProUGUI dayText;
    void Awake()
    {
        dayText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        dayText.text = GameManager.Instance.Day.ToString();
    }

}
