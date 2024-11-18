using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DefaultTextBox : MonoBehaviour
{
    [Header("Background Configuration")]
    public float boxWidth;
    public float boxHeight;
    public Image inputImage;

    [Header("Text Configuration")]
    public string inputText;
    public float maxFontSize = 40f;
    public float minFontSize = 10f;

    [Header("Text Styling")]
    public TMP_FontAsset inputFont;
    public Color inputColor;
    public TextAlignmentOptions textBoxOptions;

    private TextMeshProUGUI text;

    private void Awake()
    {
        inputImage = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AssignDefaultValues();
        ScaleTextToFit();
    }

    private void OnValidate()
    {
        inputImage = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        AssignDefaultValues();
        ScaleTextToFit();
    }
    void AssignDefaultValues()
    {
        //Background
        inputImage.rectTransform.sizeDelta = new Vector2(boxWidth, boxHeight);
        //Text
        text.text = inputText;
        text.color = inputColor;
        text.alignment = textBoxOptions;
        text.font = inputFont;
    }
    void ScaleTextToFit()
    {
        if (text != null && inputImage != null)
        {
            RectTransform textRect = text.GetComponent<RectTransform>();
            RectTransform backgroundRect = inputImage.GetComponent<RectTransform>();

            text.enableAutoSizing = true;

            text.fontSizeMin = minFontSize; //smallest font size
            text.fontSizeMax = maxFontSize; //largest font size

            //match text width and height to fit within the background's bounds
            textRect.sizeDelta = new Vector2(
                backgroundRect.rect.width * 0.9f,  //optional 90% padding
                backgroundRect.rect.height * 0.9f  //optional 90% padding
            );
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
