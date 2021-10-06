using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlScriptForMenu : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public GameObject[] backGround = new GameObject[3];
    public static bool krasnodarLvl = false;
    public static bool schoolLvl = true;
    public static bool lasvegasrLvl = false;
    public static bool swipeLeft = false;
    public static bool swipeRight = false;

    private void Start()
    {
        schoolLvl = true;
        lasvegasrLvl = false;
        krasnodarLvl = false;
    }

    private void Awake()
    {
        schoolLvl = true;
        lasvegasrLvl = false;
        krasnodarLvl = false;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                if (!swipeRight && krasnodarLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[2], new Vector2(-51.8f, 0.34f), Quaternion.identity);
                    swipeRight = true;
                }
                else if (!swipeRight && schoolLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[1], new Vector2(-32f, 1.46f), Quaternion.identity);
                    swipeRight = true;
                }
                else if (!swipeRight && lasvegasrLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[0], new Vector2(-58.8f, 0f), Quaternion.identity);
                    swipeRight = true;
                }
            }
            else
            {
                if (!swipeLeft && krasnodarLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[1], new Vector2(67.2f, 1.46f), Quaternion.identity);
                    swipeLeft = true;
                }
                else if (!swipeLeft && schoolLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[0], new Vector2(58f, 0f), Quaternion.identity);
                    swipeLeft = true;
                }
                else if (!swipeLeft && lasvegasrLvl && !Buttons.Shop)
                {
                    Instantiate(backGround[2], new Vector2(36.2f, 0.34f), Quaternion.identity);
                    swipeLeft = true;
                }
            }

        }
        else if ((Mathf.Abs(eventData.delta.x)) < (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.y > 0)
            {
            }
            else
            {
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}