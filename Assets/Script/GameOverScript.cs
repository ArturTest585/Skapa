using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public static bool GameOverBool = true;
    public Animator anim;
    private void FixedUpdate()
    {
        if (HeroClassNew.live <= 0 && GameOverBool)
        {
            anim.Play("GameOver");
        }
    }
    
    private void GameOverAnimEnd()
    {
        GameOverBool = false;
    }   
}
