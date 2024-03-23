using System;
using System.Collections;
using Controller;
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
        if (MenuController.isEventMode() && MenuController.checkExceededTimeLimit())
        {
            scenesVisited = 0;
            MenuController.resetStartTime();
            SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(GoToSceneRoutine());
        if (MenuController.isEventMode() && scenesVisited >= MenuController.getMaxScenes() && !MenuController.checkExceededTimeLimit())
        {
            scenesVisited = 0;
            MenuController.resetStartTime();
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