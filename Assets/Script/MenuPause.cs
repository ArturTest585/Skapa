using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause, pause, sound, menuFail;

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Resume":
                menuPause.SetActive(false);
                pause.SetActive(true);
                Time.timeScale = 1;
                break;
            case "Restart":
                if (SceneManager.GetActiveScene().name == "Level_Krasnodar") Application.LoadLevel("Level_Krasnodar");
                else if (SceneManager.GetActiveScene().name == "Level_School") Application.LoadLevel("Level_School");
                else if (SceneManager.GetActiveScene().name == "Level_LasVegas") Application.LoadLevel("Level_LasVegas");
                Time.timeScale = 1;
                break;
            case "Home":
                Application.LoadLevel("Main_Menu");
                Time.timeScale = 1;
                break;
            case "Sound":
                menuPause.SetActive(false);
                sound.SetActive(true);
                break;
            case "Back":
                if (HeroClassNew.live <= 0)
                {
                    menuFail.SetActive(true);
                    sound.SetActive(false);
                }
                else
                {
                    menuPause.SetActive(true);
                    sound.SetActive(false);
                }
                break;
        }
    }
}
