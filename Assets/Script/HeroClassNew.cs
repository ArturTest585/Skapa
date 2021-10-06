using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroClassNew : MonoBehaviour
{
    /// <summary>
    /// Анимация
    /// </summary>
    public Animator anim;
    /// <summary>
    /// Стартовые координаты герия
    /// </summary>
    public float startPositionY = -0.5f;
    public float startPositionX = -7f;
    /// <summary>
    /// Индекс и смещение
    /// </summary>
    public static int index = 2;
    private float _y;
    
    /// <summary>
    /// Объект физики
    /// </summary>
    private Rigidbody2D _mRigidbody;

    /// <summary>
    /// Переменные для свайпа и тача
    /// </summary>
    private Vector2 _beg, _end;
    private Touch _touch;
    
    /// <summary>
    /// Переменные для прыжка
    /// </summary>
    public float force = 50f;
    public static int extraJump;
    public int extraJumpValue;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask whatisGround;
    public static bool isGround = true;

    public static bool MoveTop = false;
    public static bool MoveBot = false;
    public static bool JumpHero = false;
// <<<<<<< Updated upstream
    
    public static int live = 3;
    public static bool Jump = false;
    public static bool JumpTwo = false;
    public static bool _stopTwoJump = false;
    public static bool Fail = false;

    public float copyMoveCamera;

    public GameObject menuFail;

    public static bool stopControlBool = true;
    
    public static int moneyFinal;

    public GameObject GameOver;

    public GameObject Ouch;

    public GameObject pauseSprite;
    public float ZakeMidLine = 0.5f;
    public float UpForce = 0.3f;
    public float DownForce = -0.2f;
    private string currentAnimation;
    public static bool FailDown;
    

// >>>>>>> Stashed changes

    [Header("Жизни")] public GameObject[] liveZak = new GameObject[9];

    /// <summary>
    /// Функция старта
    /// </summary>
    void Start()
    {
        Fail = false;
        FailDown = false;
        extraJump = 0;
        gameObject.transform.localScale = new Vector3(ZakeMidLine, ZakeMidLine,0f);
        _mRigidbody = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(startPositionX, startPositionY, 0);
        extraJump = extraJumpValue;
        // anim.SetBool("ReadyKick", false);
        moneyFinal = PlayerPrefs.GetInt("Money");
        index = 2;
        anim = GetComponent<Animator>();
        if (!GameOverScript.GameOverBool && !Fail)
        {
            ChangeAnimation("Kick");   
        }
    }

    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "Fail") return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    /// <summary>
    /// Функция начала
    /// </summary>\
    private void Awake()
    {
        // SwipeDetector.OnSwipe += Move;
        live = 3;
        Move_Camera.cameraSpeed = 10f;
        GetComponent<SpriteRenderer>().sortingOrder = 4;
        // Fail = false;
        stopControlBool = true;
        GameOverScript.GameOverBool = true;
    }
    
    public void Jumping()
    {
        if (Jump && extraJump == 1 && !MoveTop && !MoveBot && !Fail && stopControlBool) 
        {
            // anim.SetBool("ReadyJump", true);
            ChangeAnimation("Jump");
            isGround = false;
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = true;
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = true;
            GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().Play();
            extraJump++;
        }
    }

    public void JumpingTwo()
    {
        if (JumpTwo && extraJump == 3 && !_stopTwoJump && !MoveTop && !MoveBot && !Fail && stopControlBool &&
            PlayerPrefs.GetInt("TrickMethodPick") != 1 && PlayerPrefs.GetInt("TrickNolliePick") != 1 &&
            PlayerPrefs.GetInt("TrickNollieFlipPick") != 1 && PlayerPrefs.GetInt("TrickChristPick") != 1)
        {
            Debug.Log(extraJump);
            Debug.Log("JUMP TWO ON");
            // anim.SetBool("ReadyJumpTwo", true);
            ChangeAnimation("JumpTwo");
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = false;
            extraJump++;
        } else if (JumpTwo && extraJump == 3 && !_stopTwoJump && !MoveTop && !MoveBot && !Fail && stopControlBool &&
                   PlayerPrefs.GetInt("TrickMethodPick") == 1)
        {
            Debug.Log(extraJump);
            Debug.Log("TrickMethodPick ON");
            // anim.SetBool("TrickMethod", true);
            ChangeAnimation("TrickMethod");
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = false;
            extraJump++;
        }
        else if (JumpTwo && extraJump == 3 && !_stopTwoJump && !MoveTop && !MoveBot && !Fail && stopControlBool &&
                 PlayerPrefs.GetInt("TrickNolliePick") == 1)
        {
            Debug.Log(extraJump);
            Debug.Log("TrickNollie ON");
            // anim.SetBool("TrickNollie", true);
            ChangeAnimation("TrickNollie");
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = false;
            extraJump++;
        }
        else if (JumpTwo && extraJump == 3 && !_stopTwoJump && !MoveTop && !MoveBot && !Fail && stopControlBool &&
                 PlayerPrefs.GetInt("TrickNollieFlipPick") == 1)
        {
            Debug.Log(extraJump);
            Debug.Log("TrickNollieFlip ON");
            // anim.SetBool("TrickNollieFlip", true);
            ChangeAnimation("TrickNollieFlip");
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = false;
            extraJump++;
        }
        else if (JumpTwo && extraJump == 3 && !_stopTwoJump && !MoveTop && !MoveBot && !Fail && stopControlBool &&
                 PlayerPrefs.GetInt("TrickChristPick") == 1)
        {
            Debug.Log(extraJump);
            Debug.Log("TrickChrist ON");
            // anim.SetBool("TrickChrist", true);
            ChangeAnimation("TrickChrist");
            _mRigidbody.AddForce(new Vector2(0f, force));
            JumpTwo = false;
            extraJump++;
        }
    }

    /// <summary>
    /// Функция обновления
    /// </summary>
    private void Update()
    {
        Jumping();
        JumpingTwo();
        if (!Jump && !JumpTwo && !Fail && stopControlBool && currentAnimation != "Kick" && !GameOverScript.GameOverBool)
        {
            ChangeAnimation("Slide");   
        }
        OnEnableOrDisableLines();

        if (stopControlBool && !Fail && !Jump && !JumpTwo && MoveTop && isGround)
        {
            // anim.SetBool("UpLine", true);
            if (!Fail && !GameOverScript.GameOverBool)
            {
                ChangeAnimation("UpLine");
            }
            _mRigidbody.AddForce(new Vector2(0f, UpForce));
            Debug.Log("TOP ON");
        }
        else if (stopControlBool && !Fail && !Jump && !JumpTwo && MoveBot && isGround)
        {
            // anim.SetBool("DownLine", true);
            if (!Fail && !GameOverScript.GameOverBool)
            {
                ChangeAnimation("DownLine");   
            }
            _mRigidbody.AddForce(new Vector2(0f, DownForce));
            Debug.Log("BOT ON");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            // anim.SetBool("ReadyJump", false);
            // if (PlayerPrefs.GetInt("TrickMethodPick") != 1 && PlayerPrefs.GetInt("TrickNolliePick") != 1 &&
            //     PlayerPrefs.GetInt("TrickNollieFlipPick") != 1 && PlayerPrefs.GetInt("TrickChristPick") != 1)
            // {
            //     // anim.SetBool("ReadyJumpTwo", false);       
            //     // ChangeAnimation("JumpTwo");
            // } 
            // else if (PlayerPrefs.GetInt("TrickMethodPick") == 1)
            // {
            //     // anim.SetBool("TrickMethod", false);   
            //     // ChangeAnimation("TrickMethod");
            // }
            // else if (PlayerPrefs.GetInt("TrickNolliePick") == 1)
            // {
            //     // anim.SetBool("TrickNollie", false);  
            //     // ChangeAnimation("TrickNollie");
            // }
            // else if (PlayerPrefs.GetInt("TrickNollieFlipPick") == 1)
            // {
            //     // anim.SetBool("TrickNollieFlip", false);   
            //     // ChangeAnimation("TrickNollieFlip");
            // }
            // else if (PlayerPrefs.GetInt("TrickChristPick") == 1)
            // {
            //     // anim.SetBool("TrickChrist", false);   
            //     // ChangeAnimation("TrickChrist");
            // }

            Jump = false;
            isGround = true;
            extraJump = 0;
            JumpTwo = false;
            _stopTwoJump = false;
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = false;
            GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().Play();
        }
    }

    /// <summary>
    /// Фиксированное обновление
    /// </summary>
    private void FixedUpdate()
    {
        Debug.Log(Move_Camera.cameraSpeed);
        if (Move_Camera.cameraSpeed == 5f && !Fail)
        {
            Move_Camera.cameraSpeed = copyMoveCamera;
        }
        
        if (MoveControl.animDownLine)
        {
            // anim.SetBool("DownLine", true);
            ChangeAnimation("DownLine");
        }

        if (MoveControl.animUpLine)
        {
            // anim.SetBool("UpLine", true);
            ChangeAnimation("UpLine");
        }

        if (live == 3)
        {
            liveZak[0].SetActive(true);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);
                ChangeAnimation("Fail");
            }
        }
        else if (live == 2)
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(true);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);   
                ChangeAnimation("Fail");
            }
        }
        else if (live == 1)
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(true);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);   
                ChangeAnimation("Fail");
            }
        }
        else
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(true);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);   
                ChangeAnimation("Fail");
            }
        }

        if (live <= 0 && !GameOverScript.GameOverBool)
        {
            GameOverTrue();
        }
    }

    /// <summary>
    /// Отклчение или включение линий
    /// </summary>
    private void OnEnableOrDisableLines()
    {
        switch (index)
        {
            case 1:
                GetComponent<SpriteRenderer>().sortingOrder = 6;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                break;
        }
    }

    private void StopGame()
    {
        GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = true;
        if (live > 0 && Fail)
        {
            // Move_Camera.cameraSpeed = 0f;
            // anim.SetBool("Fail", false);
            ChangeAnimation("Up");
        }
        else if (live <= 0 && Fail)
        {
            // Move_Camera.cameraSpeed = 0f;
            pauseSprite.SetActive(false);
            GameOver.SetActive(true);
            GameOverScript.GameOverBool = true;
        }
        
    }

    private void StopTwoJump()
    {
        _stopTwoJump = true;
        isGround = true;
    }

    private void CameraNonStop()
    {
        FailDown = false;
        Move_Camera.cameraSpeed = 10f;
        DinamicBG.StopBG = false;
    }

    private void UpZakeClose()
    {
        if (live != 0)
        {
            stopControlBool = true;
            // anim.SetBool("Up", false);
            // ChangeAnimation("Up");
            Fail = false;
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = false;
            Move_Camera.cameraSpeed = copyMoveCamera;
            ChangeAnimation("Kick");
        }
    }

    private void SmallRace()
    {
        if (Move_Camera.cameraSpeed > 6f)
        {
            copyMoveCamera = Move_Camera.cameraSpeed;   
        }
        if (FailDown) Move_Camera.cameraSpeed = 5f;
    }

    private void stopControl()
    {
        Ouch.SetActive(true);
        OuchScript.OuchBool = true;
        stopControlBool = false;
    }

    public void GameOverTrue()
    {
        Time.timeScale = 0;
        menuFail.SetActive(true);  
        Fail = false;
        moneyFinal += Move_Camera.count;
        PlayerPrefs.SetInt("Money", moneyFinal);  
    }

    public void DownLineTrue()
    {
        if (!FailDown) anim.SetBool("DownLine", false);
    }

    public void UpLineTrue()
    {
        if (!FailDown) anim.SetBool("UpLine", false);
    }

    public void PlayAnimSlide()
    {
        ChangeAnimation("Slide");
    }

    public void StopCamera()
    {
        Move_Camera.cameraSpeed = 0f;
        DinamicBG.StopBG = true;
        FailDown = false;
    }
}
