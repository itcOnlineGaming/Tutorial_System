using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject TextBoxPrefab;
    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private GameObject ShakePrefab;

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

    private List<GameObject> popUpsList = new List<GameObject>();

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
            lifeTime = 3,
            popUpId = 0,
        };

        ArrowPopUpData tempf = new ArrowPopUpData
        {
            angle = 46,
            radius = 60,
            lifeTime = 3,
            popUpId = 0,
        };

        //ShowDefaultTextBoxPopUp(point, temp);
        //ShowTextBoxWithImage(temp, point);
        //ShowArrowPopUp(point, tempf);

        ShowShakePopUp(point, temp);
    }

    public void ShowShakePopUp(Transform position, PopUpData data)
    {
        GameObject popup = Instantiate(ShakePrefab, position);
        popup.GetComponent<PopUp>().popUpData = data;
        popup.GetComponentInChildren<BackGroundImage>().SetUpImage(data);
        popup.GetComponent<LifeTime>().SetLifetime(data.lifeTime);
        popUpsList.Add(popup);
    }
    public void ShowArrowPopUp(Transform position, ArrowPopUpData data)
    {
        GameObject popup = Instantiate(ArrowPrefab, position);
        popup.GetComponent<PopUp>().ArrowpopUpData = data;
        popup.GetComponent<ArrowIndicator>().SetUp(data);
        popup.GetComponent<ArrowIndicator>().setObjectToIndicate(position);
        popUpsList.Add(popup);
    }

    public void ShowDefaultTextBoxPopUp(Transform position, PopUpData data)
    {
        var popup = Instantiate(TextBoxPrefab, position);
        popup.GetComponent<PopUp>().popUpData = data;
        popup.GetComponentInChildren<DefaultTextBox>().setUp(data);
        popup.GetComponent<LifeTime>().SetLifetime(data.lifeTime);
        popUpsList.Add(popup);
    }

    public void closePopUp(int id)
    {
        foreach (var item in popUpsList)
        {
            if (item.GetComponent<PopUp>().popUpData.popUpId == id)
            { 
                Destroy(item);
                popUpsList.Remove(item);
            
            }
        }
    }
}
