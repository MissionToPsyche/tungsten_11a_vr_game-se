using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string scene;
    public FadeScreen fadeScreen;
    private int scenesVisited = 0;

    private void Awake()
    {
        scenesVisited++;
        //Empty
    }

    public void Update()
    {
        if (MainMenuController.isEventMode() && MainMenuController.checkExceededTimeLimit())
        {
            scenesVisited = 0;
            MainMenuController.resetStartTime();
            SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(GoToSceneRoutine());
        if (MainMenuController.isEventMode() && scenesVisited >= MainMenuController.getMaxScenes() && !MainMenuController.checkExceededTimeLimit())
        {
            scenesVisited = 0;
            MainMenuController.resetStartTime();
            SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu
        } else
        {
            // No need to increment scenesVisited here, the Awake() method will increment it when the next scene loads
            SceneManager.LoadScene(scene);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Empty
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Empty
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Empty
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Empty
    } 

    IEnumerator GoToSceneRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
    }

}