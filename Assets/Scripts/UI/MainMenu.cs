using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static void PlayGame ()
    {
        SceneManager.LoadScene("UI + UI");
    }

    public static void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen"); // Just in case
    }
    public static void options()
    {
        SceneManager.LoadScene("Options"); // Options menu
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); // To go back to menu if possible
    }

    public static void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
