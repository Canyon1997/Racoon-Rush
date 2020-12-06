using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = true; //mouse cursor will be visible in main menu and game over screen
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SantisGameplay");
    }

    public void Return()
    {
        SceneManager.LoadScene("SantisMenus");
    }
    public void QuitGame()
    {
        Debug.Log("I quit!!!");
        Application.Quit();
    }
}
