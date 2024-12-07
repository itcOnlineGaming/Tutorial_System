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
        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.ArrowTutorial, popUpManager.ShowArrowPopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.TextBoxTutorial, popUpManager.ShowDefaultTextBoxPopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.ShakeTutorial, popUpManager.ShowShakePopUp);

        TutorialServiceLocator.TutorialEventManager.Subscribe(TutorialEvent.SwipeTutorial, popUpManager.ShowSwipePopUp);

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
            popUpId = 0,
        };

        SwipePopUpData SwipeData = new SwipePopUpData()
        {
            state = "SwipeUp",
            lifeTime = 3f,
            popUpId = 0,
        };

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.TextBoxTutorial, position, TextBoxData);

        yield return new WaitForSeconds(3f);

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.ArrowTutorial, position, ArrowData);

        yield return new WaitForSeconds(3f);

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.ShakeTutorial, position, TextBoxData);

        yield return new WaitForSeconds(3f);

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.SwipeTutorial, position, SwipeData);

        yield return new WaitForSeconds(3f);

        SwipeData.state = "SwipeDown";

        TutorialServiceLocator.TutorialEventManager.RaiseEvent(TutorialEvent.SwipeTutorial, position, SwipeData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
