using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        
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
