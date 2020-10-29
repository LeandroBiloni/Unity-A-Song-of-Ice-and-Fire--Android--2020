using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject controlsSub;
    public GameObject creditsSub;
    public GameObject exitSub;
    public GameObject console;
    public GameManager manager;
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void Controls()
    {
        controlsSub.SetActive(true);
    }

    public void BackControls()
    {
        controlsSub.SetActive(false);
    }

    public void Credits()
    {
        creditsSub.SetActive(true);
    }

    public void BackCredits()
    {
        creditsSub.SetActive(false);
    }

    public void ExitSubMenu()
    {
        exitSub.SetActive(true);
    }

    public void ExitCancel()
    {
        exitSub.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }


    //Menu Pausa
    public void ResumeLevel()
    {
        gameObject.SetActive(false);
        //manager.isPaused = false;
        Time.timeScale = 1;
        console.SetActive(false);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenConsole()
    {
        console.SetActive(true);
    }
}
