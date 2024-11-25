using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TextBoxWithImage : DefaultTextBox
{
    private DefaultTextBox textBox;
    private GameObject imageObject;
    private GameObject boxBackground;


    private void Awake()
    {
        textBox = GetComponentInChildren<DefaultTextBox>();
        boxBackground = transform.Find("BackGround").gameObject;
        imageObject = transform.Find("Image").gameObject;
    }

    public void setUpText(PopUpData popUpData)
    {
        textBox.setUp(popUpData);
       // UpdateImageScales();
    }
    private void Start()
    {
        if (imageObject != null)
        {
            UpdateImageScales();
        }
        else
        {
            Debug.LogError("Please assign both image references in the inspector.");
        }
        SetUpElements();
    }

    //public Vector2 GetBoxRatio()
    //{
    //    //return new Vector2(boxWidth * 0.6f, boxHeight * 0.4f);
    //}
    private void SetUpElements()
    {
        //Background
       // boxBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(boxWidth, boxHeight);
        //if (inputImage)
        //{
        //    imageObject.GetComponent<Image>().sprite = inputImage;
        //}
    }

    // This method updates the width of the images based on the 3:2 ratio
    private void UpdateImageScales()
    {
        // Get RectTransforms of both images
        RectTransform rect1 = textBox.GetComponent<RectTransform>();
        RectTransform rect2 = imageObject.GetComponent<RectTransform>();

        //rect1.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, boxWidth * 0.6f); // 3 / (3+2)
        //rect2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, boxWidth * 0.4f); // 2 / (3+2)

        //rect1.anchoredPosition = new Vector2(-boxWidth / 2f + boxWidth * 0.6f / 2f, 0); // Align left
        //rect2.anchoredPosition = new Vector2(boxWidth / 2f - boxWidth * 0.4f / 2f, 0);  // Align right
    }
}
