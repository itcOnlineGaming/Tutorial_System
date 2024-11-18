using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DefaultTextBox : MonoBehaviour
{
    [Header("Background Configuration")]
    public float boxWidth;
    public float boxHeight;
    public Sprite inputSprite;

    [Header("Text Configuration")]
    public string inputText;
    public float maxFontSize = 40f;
    public float minFontSize = 10f;

    [Header("Text Styling")]
    public TMP_FontAsset inputFont;
    public Color inputColor;
    public TextAlignmentOptions textBoxOptions;

    private TextMeshProUGUI text;
    private GameObject backgroundObject;

    private void Awake()
    {
        backgroundObject = transform.Find("BackGround").gameObject;
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        AssignDefaultValues();
        ScaleTextToFit();
    }
    /// <summary>
    /// debug inside editor
    /// </summary>
    private void OnValidate()
    {
        backgroundObject = transform.Find("BackGround").gameObject;
        text = GetComponentInChildren<TextMeshProUGUI>();
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
        backgroundObject.GetComponent<Image>().sprite = inputSprite;
        //Text
        text.text = inputText;
        text.color = inputColor;
        text.alignment = textBoxOptions;
        if (inputFont)
        {
            text.font = inputFont;
        }
    }

    /// <summary>
    /// Scales text to fit inside of background bounds
    /// </summary>
    void ScaleTextToFit()
    {
        if (text != null && backgroundObject != null)
        {
            RectTransform textRect = text.gameObject.GetComponent<RectTransform>();
            RectTransform backgroundRect = backgroundObject.GetComponent<RectTransform>();

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
