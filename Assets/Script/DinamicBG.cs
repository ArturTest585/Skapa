using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinamicBG : MonoBehaviour
{
    public float citySpeed = 0.03f;
    public float mountainsSpeed = 0.01f;
    public static bool StopBG = false;

    private void Start()
    {
        StopBG = false;
    }

    void FixedUpdate()
    {
        if (gameObject.transform.name == "BG_CityAll" && !StopBG || gameObject.transform.name == "BG_City_Kras" && !StopBG)
        {
            gameObject.transform.position -= new Vector3(citySpeed, 0f, 0f);
            Debug.Log(gameObject.transform.localPosition.x);
        }
        
        if (gameObject.transform.name == "BG_MountainsAll" && !StopBG || gameObject.transform.name == "BG_Sky_Kras" && !StopBG)
        {
            gameObject.transform.position -= new Vector3(mountainsSpeed, 0f, 0f);
        }
        
        if (gameObject.transform.localPosition.x <= -33.45f)
        {
            gameObject.transform.localPosition = new Vector3(0f, 0f, 10f);
        }
    }
}
