using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Transform player;
    public GameObject lineGame;
    public static bool topLine = false;
    public bool topLineRepeat;
    public static bool midLine = false;
    public bool midLineRepeat;
    public static bool botLine = false;
    public bool botLineRepeat;
    public static bool animUpLine = false;
    public static bool animDownLine = false;
    public GameObject ZakeScale;
    public float mouseMax = -1.6f;
    public float mouseMin = -4.45f;
    public float lineTop = -4.2f;
    public float lineMid = -5.7f;
    public float lineBot = -7.5f;

    private void Start()
    {
        topLine = false;
        midLine = true;
        botLine = false;
        animUpLine = false;
        animDownLine = false;
        topLineRepeat = false;
        midLineRepeat = true;
        botLineRepeat = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.y = mouse.y > mouseMax ? mouseMax : mouse.y;
        mouse.y = mouse.y < mouseMin ? mouseMin : mouse.y;
        if (HeroClassNew.stopControlBool && !HeroClassNew.Fail)
        {
            player.position = new Vector2(player.position.x, mouse.y);    
        }
        
        if (player.transform.position.y >= -2f && player.transform.position.y <= -1.6f && !topLine && Input.touchCount == 1)
        {
            topLine = true;
            midLine = false;
            botLine = false;
            topLineRepeat = true;
            midLineRepeat = false;
            botLineRepeat = false;
            HeroClassNew.index = 3;
        }
        else if (player.transform.position.y <= -3.85f && player.transform.position.y >= -4.45f && !botLine && Input.touchCount == 1)
        {
            topLine = false;
            midLine = false;
            botLine = true;
            topLineRepeat = false;
            midLineRepeat = false;
            botLineRepeat = true;
            HeroClassNew.index = 1;
        }
        else if (player.transform.position.y < -2f && player.transform.position.y > -3.85f && !midLine && Input.touchCount == 1)
        {
            topLine = false;
            midLine = true;
            botLine = false;
            topLineRepeat = false;
            midLineRepeat = true;
            botLineRepeat = false;
            HeroClassNew.index = 2;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(Input.touchCount);
        if (topLine)
        {
            if (lineGame.transform.position.y < lineTop)
            {
                animUpLine = true;
                lineGame.transform.position += new Vector3(0f, 0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(-0.008f, -0.008f, 0f);
            }
            else
            {
                animUpLine = false;
            }
        }
        else if (botLine)
        {
            if (lineGame.transform.position.y > lineBot)
            {
                animDownLine = true;
                lineGame.transform.position += new Vector3(0f, -0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(0.008f, 0.008f, 0f);
            }
            else
            {
                animDownLine = false;
            }
        }
        else if (midLine)
        {
            if (lineGame.transform.position.y > lineMid)
            {
                animDownLine = true;
                lineGame.transform.position += new Vector3(0f, -0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(0.008f, 0.008f, 0f);
            }
            else
            {
                animDownLine = false;
            }
            
            
            if (lineGame.transform.position.y < lineMid)
            {
                animUpLine = true;
                lineGame.transform.position += new Vector3(0f, 0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(-0.008f, -0.008f, 0f);
            } 
            else
            {
                animUpLine = false;
            }
        }
    }
}
