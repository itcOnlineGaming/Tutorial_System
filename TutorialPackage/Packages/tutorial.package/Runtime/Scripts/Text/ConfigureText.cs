using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigureText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnValidate()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        assignValues();
    }
    void Start()
    {
        assignValues();
    }

    void assignValues()
    {
       
    }

    
}
