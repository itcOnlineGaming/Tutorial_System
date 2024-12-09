using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TutorialController : MonoBehaviour
{
    public Sprite PopUpImage;
    public TMP_FontAsset fontAsset;
    public PopUpManager popUpManager;

    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        //Subscirbe to all events
        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.ArrowTutorial, popUpManager.ShowArrowPopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.TextBoxTutorial, popUpManager.ShowDefaultTextBoxPopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.ShakeTutorial, popUpManager.ShowShakePopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.SwipeTutorial, popUpManager.ShowSwipePopUp);

        //create your own way of showing the popUps
        StartCoroutine(ShowTutorials());
    }

    public IEnumerator ShowTutorials()
    {
        PopUpData TextBoxData = new PopUpData()
        {
            BodyText = "This is text example for tutorials",
            BackgroundImage = PopUpImage,
            width = 900,
            height = 550,
            textColor = Color.black,
            lifeTime = 3f,
            popUpId = 0,
        };

        ArrowPopUpData ArrowData = new ArrowPopUpData()
        {
            radius = 60,
            angle = 30,
            lifeTime = 3f,
            popUpId = 1,
        };

        SwipePopUpData SwipeData = new SwipePopUpData()
        {
            state = "SwipeDown",
            lifeTime = 3f,
            popUpId = 2,
        };

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.TextBoxTutorial, position, TextBoxData);

        yield return new WaitForSeconds(3f);

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.ArrowTutorial, position, ArrowData);

       yield return new WaitForSeconds(3f);

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.ShakeTutorial, position, TextBoxData);

       yield return new WaitForSeconds(3f);

       TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.SwipeTutorial, position, SwipeData);

       yield return new WaitForSeconds(3f);

    }

}
