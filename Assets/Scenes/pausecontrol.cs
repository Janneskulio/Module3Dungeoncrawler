using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausecontrol : MonoBehaviour
{
    [SerializeField] GameObject pausetext, pausecontinue, pausemainmenu;
    void Start()
    {
        pausetext.SetActive(false);
        pausecontinue.SetActive(false);
        pausemainmenu.SetActive(false);
    }
    public void tomainmenu()
    {SceneManager.LoadScene("Mainmenu");}
    public void pausetimecontinue()
    {
        Time.timeScale = 1;
        pausetext.SetActive(false);
        pausecontinue.SetActive(false);
        pausemainmenu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausetext.SetActive(true);
            pausecontinue.SetActive(true);
            pausemainmenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
