using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{
    public Canvas canvas;

    private void Awake()
    {
        canvas = GameObject.FindAnyObjectByType<Canvas>();
    }

    void Start()
    {
        // Get the Canvas Scaler
        CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();

        // Adjust scaling dynamically (example)
        scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
    }
}
