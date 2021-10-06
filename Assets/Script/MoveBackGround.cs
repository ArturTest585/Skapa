using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackGround : MonoBehaviour
{
    public float cameraSpeedForMenu = 1f;
    public GameObject[] backGroundForDestroy = new GameObject[3];
    private int i = new int();


    private void Start()
    {
        i = 0;
    }

    private void FixedUpdate()
    {
        i++;
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.krasnodarLvl)
        {
            gameObject.transform.position += new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "School(Clone)" && i == 33)
            {
                Debug.Log("Sch");
                ControlScriptForMenu.krasnodarLvl = false;
                ControlScriptForMenu.schoolLvl = true;
                ControlScriptForMenu.swipeRight = false;
                var ObjectBonus1 = GameObject.Find("Krasnodar(Clone)");
                Destroy (ObjectBonus1);
                i = 0;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.krasnodarLvl)
        {
            gameObject.transform.position -= new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "LasVegas(Clone)" && i == 40)
            {
                Debug.Log("Las");
                ControlScriptForMenu.krasnodarLvl = false;
                ControlScriptForMenu.lasvegasrLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                var ObjectBonus1 = GameObject.Find("Krasnodar(Clone)");
                Destroy (ObjectBonus1);
                i = 0;
            }
        }
        
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.schoolLvl)
        {
            gameObject.transform.position += new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "LasVegas(Clone)" && i == 22)
            {
                Debug.Log("Las");
                ControlScriptForMenu.schoolLvl = false;
                ControlScriptForMenu.lasvegasrLvl = true;
                ControlScriptForMenu.swipeRight = false;
                var ObjectBonus1 = GameObject.Find("School(Clone)");
                Destroy (ObjectBonus1);
                var ObjectBonus2 = GameObject.Find("School");
                Destroy (ObjectBonus2);
                i = 0;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.schoolLvl)
        {
            gameObject.transform.position -= new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "Krasnodar(Clone)" && i == 33)
            {
                Debug.Log("Kras");
                ControlScriptForMenu.schoolLvl = false;
                ControlScriptForMenu.krasnodarLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                var ObjectBonus1 = GameObject.Find("School(Clone)");
                Destroy (ObjectBonus1);
                var ObjectBonus2 = GameObject.Find("School");
                Destroy (ObjectBonus2);
                i = 0;
            }
        }
        
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.lasvegasrLvl)
        {
            gameObject.transform.position += new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "Krasnodar(Clone)" && i == 40)
            {
                Debug.Log("Kras");
                ControlScriptForMenu.lasvegasrLvl = false;
                ControlScriptForMenu.krasnodarLvl = true;
                ControlScriptForMenu.swipeRight = false;
                var ObjectBonus1 = GameObject.Find("LasVegas(Clone)");
                Destroy (ObjectBonus1);
                i = 0;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.lasvegasrLvl)
        {
            gameObject.transform.position -= new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "School(Clone)" && i == 22)
            {
                Debug.Log("Sch");
                ControlScriptForMenu.lasvegasrLvl = false;
                ControlScriptForMenu.schoolLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                var ObjectBonus1 = GameObject.Find("LasVegas(Clone)");
                Destroy (ObjectBonus1);
                i = 0;
            }
        }
    }
}
