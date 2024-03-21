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

    //private Renderer planetRenderer;
    public Vector3 hoverScaleIncrease = new Vector3(0.1f, 0.1f, 0.1f); // How much to scale up on hover
    private Vector3 originalScale;
    private bool isHovered = false;
    public Vector3 rotationSpeed = new Vector3(0, 30, 0);

    private void Awake()
    {
        scenesVisited++;

        //planetRenderer = GetComponent<Renderer>(); 

        originalScale = transform.localScale;


    }

    public void Update()
    {
        if (MainMenuController.isEventMode() && MainMenuController.checkExceededTimeLimit())
        {
            scenesVisited = 0;
            MainMenuController.resetStartTime();
            SceneManager.LoadScene("MainMenu"); // TODO in the future, this will redirect to the next player menu
        }
        if (isHovered) 
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
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
        isHovered = true; // Start rotating
        transform.localScale = originalScale + hoverScaleIncrease; // Also scale up for hover effect
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false; // Stop rotating
        transform.localScale = originalScale; // Revert to original scale
    }



    IEnumerator GoToSceneRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
    }

}