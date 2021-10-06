using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public static bool moneyBool = false;
    public int indexMoney;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level_LasVegas" || SceneManager.GetActiveScene().name == "Level_School" || SceneManager.GetActiveScene().name == "Level_Krasnodar")
        {
            if (gameObject.transform.position.y == -0.15f 
                || gameObject.transform.position.y == 0.95f)
            {
                indexMoney = 3;
            }
            else if (gameObject.transform.position.y == -1.1f 
                     || gameObject.transform.position.y == 0f)
            {
                indexMoney = 2;
            }
            else
            {
                indexMoney = 1;
            }
        }
        else
        {
            if (gameObject.transform.position.y == 0.9f 
                || gameObject.transform.position.y == 2f)
            {
                indexMoney = 3;
            }
            else if (gameObject.transform.position.y == 0.4f 
                     || gameObject.transform.position.y == -0.7f)
            {
                indexMoney = 2;
            }
            else
            {
                indexMoney = 1;
            }
        }
       
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Move_Camera.count++;
            moneyBool = true;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (indexMoney == HeroClassNew.index)
        {
            if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (HeroClassNew.Fail)
        {
            Destroy(gameObject);
        }
    }
}
