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

    public void ShowShakePopUp(Transform position, PopUpData data)
    {
        GameObject popup = Instantiate(ShakePrefab, position);
        popup.GetComponent<PopUp>().popUpData = data;
        popup.GetComponentInChildren<BackGroundImage>().SetUpImage(data);
        popup.GetComponent<LifeTime>().SetLifetime(data.lifeTime);
        popUpsList.Add(popup);
    }
    public void ShowArrowPopUp(Transform position, PopUpData data)
    {
        GameObject popup = Instantiate(ArrowPrefab, position);
        popup.GetComponent<PopUp>().popUpData = data;
        popup.GetComponent<ArrowIndicator>().SetUp(data);
        popup.GetComponent<ArrowIndicator>().setObjectToIndicate(position);
        popup.GetComponent<LifeTime>().SetLifetime(data.lifeTime);
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
        List<GameObject> toRemove = new List<GameObject>();

        foreach (var item in popUpsList)
        {
            if (item.GetComponent<PopUp>().popUpData.popUpId == id)
            {
                toRemove.Add(item);  // Add to the list to be destroyed
            }
        }

        foreach (var item in toRemove)
        {
            Destroy(item); // Destroy the GameObject
            popUpsList.Remove(item); // Remove the item from the list
        }
    }
}
