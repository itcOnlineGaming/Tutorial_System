using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpData
{
    public int width;
    public int height;

    public float lifeTime;
    public int popUpId;

    public TMP_FontAsset fontAsset;

    public Color textColor;

    public string BodyText;
    public Sprite BackgroundImage;
}

public class ArrowPopUpData : PopUpData
{
    public int radius;
    public int angle;
}

public class SwipePopUpData : PopUpData
{
    public string state;
}

