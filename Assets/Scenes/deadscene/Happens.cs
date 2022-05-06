using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Happens : MonoBehaviour
{
    public void restartgame()
   {
       SceneManager.LoadScene("Game");
   }
   public void mainmenu()
   {SceneManager.LoadScene("Mainmenu");}
}
