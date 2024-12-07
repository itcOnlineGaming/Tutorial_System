using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpData
{
    //sizing
    public int width;
    public int height;
    //font
    public TMP_FontAsset fontAsset;
    //
    public Color textColor;

    public string BodyText;
    public Sprite BackgroundImage;
    public bool IsClosable;

    public float lifeTime;

    public int popUpId;
}

public class ArrowPopUpData
{
    public float lifeTime;

    public int popUpId;

    public int radius;
    public int angle;
}
