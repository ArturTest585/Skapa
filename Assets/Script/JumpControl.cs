using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    private bool multiTouchJump = false;

    private void Start()
    {
        multiTouchJump = false;
    }

    private void Update()
    {
        if (Input.touchCount > 1 && !multiTouchJump)
        {
            multiTouchJump = true;
            Jump();
        }
        else if (Input.touchCount <= 1 && multiTouchJump)
        {
            multiTouchJump = false;
        }
    }

    private void OnMouseDown()
    {
        /*Debug.Log("jump");
        Debug.Log(HeroClassNew.extraJump);*/
        if (HeroClassNew.extraJump <= 3 && Input.touchCount == 1)
        {
            HeroClassNew.extraJump++;
        }

        if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
        {
            HeroClassNew.Jump = true;
        }
        else if (HeroClassNew.Jump)
        {
            Debug.Log("Jump 2 Ready");
            HeroClassNew.JumpTwo = true;
        }
    }

    private void Jump()
    {
        if (HeroClassNew.extraJump <= 3)
        {
            HeroClassNew.extraJump++;    
        }
        if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
            HeroClassNew.Jump = true;
        else if (HeroClassNew.Jump)
        {
            Debug.Log("Jump 2 Ready");
            HeroClassNew.JumpTwo = true;   
        }
    } 
}
