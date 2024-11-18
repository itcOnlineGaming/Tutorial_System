using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to handle Close Button placement and close functionality
/// Author - Ruslan Gavrilov
/// </summary>
public class CloseButtonScript : MonoBehaviour
{
    [Header("Button Padding")]
    public float padding; //padding to not be in the corner too much

    //caribales for objects required
    private GameObject buttonObject;
    private GameObject backgroundObject;

    private void Awake()
    {
        backgroundObject = transform.Find("Background").gameObject;
        buttonObject = transform.Find("CloseButton").gameObject;
    }
    /// <summary>
    /// debug in editor
    /// </summary>
    private void OnValidate()
    {
        backgroundObject = transform.Find("BackGround").gameObject;
        buttonObject = transform.Find("CloseButton").gameObject;
        MoveToTopRight();
    }

    private void Start()
    {
        MoveToTopRight();
    }
    /// <summary>
    /// moves button object to top right
    /// </summary>
    private void MoveToTopRight()
    {
        RectTransform backgroundRect = backgroundObject.GetComponent<RectTransform>();
        RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();

        Vector2 topRight = new Vector2(
         backgroundRect.sizeDelta.x / 2 - (buttonRect.sizeDelta.x / 2) - padding, // divide the size by 2 as we are starting from the center, subtract padding
         backgroundRect.sizeDelta.y / 2 - (buttonRect.sizeDelta.y / 2) - padding
     );

        buttonRect.anchoredPosition = topRight; //set position
    }
    public void ClosePopUp()
    {
        Destroy(gameObject); //destory pop up 
    }
}
