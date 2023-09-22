using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string first_level_name;
 
    public void StartGame()
    {
        SceneManager.LoadScene(first_level_name);
    }
    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit !");
    }
}
