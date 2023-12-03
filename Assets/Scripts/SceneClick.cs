using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string scene;

    private void Awake()
    {
        //Empty
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(scene);
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