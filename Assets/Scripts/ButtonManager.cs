using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject creditsPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        creditsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void Credits()
    {
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Back()
    {
        if (controlsPanel.activeInHierarchy)
        {
            controlsPanel.SetActive(false);
        }
        else if (creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}