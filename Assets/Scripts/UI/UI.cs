using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    
    private void Awake()
    {
        Cursor.visible = false;
    }

    public void Back(InputAction.CallbackContext callbackContext)
    {
        play.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void Play(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        menu.SetActive(false);
        play.SetActive(true);
    }

    public void Options(InputAction.CallbackContext callbackContext)
    {
        
        menu.SetActive(false);
        options.SetActive(true);
    }
    
    public void Credits(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void Exit(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Application.Quit();
    }
    
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        play.SetActive(false);
        menu.SetActive(true);
    }

}
