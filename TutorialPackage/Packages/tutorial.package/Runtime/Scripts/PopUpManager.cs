using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject TextBoxPrefab;
    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private GameObject TextBoxWithImagePrefab;

    [SerializeField] private Transform point;

    private static TutorialEventManager _eventManager;
    public static TutorialEventManager TutorialEventManager
    {
        get
        {
            if (_eventManager == null)
            {
                _eventManager = TutorialEventManager.Instance;
            }
            return _eventManager;
        }
    }

    private List<GameObject> popUpsList;

    private void Start()
    {
        PopUpData temp = new PopUpData
        {
            BodyText = "Try Shaking your device to roll the dice!",
            BackgroundImage = null,
            width = 400,
            height = 300,
            textColor = Color.black,
            fontAsset = null,
            IsClosable = false,
        };

        //ShowDefaultTextBoxPopUp(temp,point);
        //ShowTextBoxWithImage(temp, point);
        //ShowArrowPopUp(point);
    }

    public void ShowArrowPopUp(Transform position)
    {
        var popup = Instantiate(ArrowPrefab, position);
        popup.GetComponent<ArrowIndicator>().setObjectToIndicate(position);
       // popUpsList.Add(popup);
    }

    public void ShowDefaultTextBoxPopUp(Transform position, PopUpData data)
    {
        var popup = Instantiate(TextBoxPrefab, position);
        popup.GetComponentInChildren<DefaultTextBox>().setUp(data);
        // popUpsList.Add(popup);
    }

    public void ShowTextBoxWithImage(PopUpData data, Transform position)
    {
        GameObject popup = Instantiate(TextBoxWithImagePrefab, position);
        popup.GetComponent<TextBoxWithImage>().setUpText(data);
       // popUpsList.Add(popup); //error here
    }

    public void closeActivePopUps()
    {
        foreach (var item in popUpsList)
        {
            Destroy(item);
        }
    }
}
