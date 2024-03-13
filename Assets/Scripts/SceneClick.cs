using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string scene;
    private int scenesVisited = 0;

    private void Awake()
    {
        scenesVisited++;
        //Empty
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (MainMenuController.isEventMode() && scenesVisited >= MainMenuController.getMaxScenes())
        {
            Debug.Log("Max scenes reached");
            SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu and reset scenesVisited to 0
        } else
        {
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

}