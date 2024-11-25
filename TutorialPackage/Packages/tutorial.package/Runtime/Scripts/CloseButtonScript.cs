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

    private void Awake()
    {
        buttonObject = this.gameObject;
    }
    /// <summary>
    /// moves button object to top right
    /// </summary>
    public void MoveToTopRight(Vector2 scale)
    {
        RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();

        Vector2 topRight = new Vector2(
         scale.x - (buttonRect.rect.size.x / 2) - padding, // divide the size by 2 as we are starting from the center, subtract padding
         scale.y - (buttonRect.rect.size.y / 2) - padding
     );
        
        buttonRect.anchoredPosition = topRight; //set position

    }
    public void ClosePopUp()
    {
        Destroy(transform.parent.gameObject); //destory pop up 
    }
}
