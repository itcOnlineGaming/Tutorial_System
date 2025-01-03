using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DefaultTextBox : MonoBehaviour
{
    private int boxWidth;
    private int boxHeight;
    private Sprite inputSprite;

    private float maxFontSize = 40f;
    private float minFontSize = 10f;

    private TextMeshProUGUI text;
   
    private GameObject backgroundObject;

    private void Awake()
    {
        backgroundObject = GetComponentInChildren<Image>().transform.parent.gameObject; // transform.Find("DefaultTextBox/BackGround").gameObject;
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void setUp(PopUpData data)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        backgroundObject = transform.Find("BackGround").gameObject;

        boxWidth = data.width;
        boxHeight = data.height;
        inputSprite = data.BackgroundImage;

        text.text = data.BodyText;
        text.font = data.fontAsset;
        text.color = data.textColor;

        AssignDefaultValues();
        ScaleTextToFit();
    }

    /// <summary>
    /// assigns all necessary variables 
    /// </summary>
    void AssignDefaultValues()
    {
        //Background
        backgroundObject.GetComponent<RectTransform>().sizeDelta = new Vector2(boxWidth, boxHeight);
        if (inputSprite)
        {
            backgroundObject.GetComponent<Image>().sprite = inputSprite;
        }
    }

    public void ScaleTextToFit()
    {
        if (text != null && backgroundObject != null)
        {
            RectTransform textRect = text.gameObject.GetComponent<RectTransform>();
            RectTransform backgroundRect = backgroundObject.GetComponent<RectTransform>();

            // Enable auto-sizing for text to fit within bounds
            text.enableAutoSizing = true;
            text.fontSizeMin = minFontSize; // Smallest font size
            text.fontSizeMax = maxFontSize; // Largest font size

            // Set text width and height to fit within the background's bounds (optional 80% padding)
            textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, backgroundRect.rect.width * 0.8f);
            textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, backgroundRect.rect.height * 0.8f);

            // Ensure the pivot and anchors are centered
            textRect.anchorMin = new Vector2(0.5f, 0.5f);
            textRect.anchorMax = new Vector2(0.5f, 0.5f);
            textRect.pivot = new Vector2(0.5f, 0.5f);

            // Center the text relative to the background
            textRect.anchoredPosition = Vector2.zero; // This will already center the text since anchors are at 0.5, 0.5

            text.alignment = TextAlignmentOptions.Center;
        }
    }

}
