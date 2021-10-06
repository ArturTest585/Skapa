using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuPause;

    private void Start()
    {
        menuPause.SetActive(false);
    }

    private void OnMouseUpAsButton()
    {
        gameObject.SetActive(false);
        menuPause.SetActive(true);
        Time.timeScale = 0;
    }
}
