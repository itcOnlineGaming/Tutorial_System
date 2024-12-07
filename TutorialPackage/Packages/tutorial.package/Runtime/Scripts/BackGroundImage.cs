using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundImage : MonoBehaviour
{
    public void SetUpImage(PopUpData data)
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(data.width, data.height);

        if(data.BackgroundImage != null)
        {
            gameObject.GetComponent<Image>().sprite = data.BackgroundImage;
        }
    }
}
