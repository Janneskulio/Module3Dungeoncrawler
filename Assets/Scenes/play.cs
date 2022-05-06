using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void playgame()
    {
       SceneManager.LoadScene("Game");
    }
    public void options()
    {
       SceneManager.LoadScene("Options");
    }
    public void backtomainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
