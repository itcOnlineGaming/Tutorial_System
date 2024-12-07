using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleImage : MonoBehaviour
{
    public RectTransform background; // Reference to the background RectTransform
    public RectTransform image;      // Reference to the image RectTransform

    void Start()
    {
        ScaleToFit();
    }

    void ScaleToFit()
    {
        float bgWidth = background.rect.width;
        float bgHeight = background.rect.height;

        float imgWidth = image.rect.width;
        float imgHeight = image.rect.height;

        // Calculate scale to fit image within the background
        float scale = Mathf.Min(bgWidth / imgWidth, bgHeight / imgHeight);
        image.localScale = new Vector3(scale, scale, 1f);
    }
}
