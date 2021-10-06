using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move_Camera : MonoBehaviour
{
    [SerializeField]
    [Header("Скорость камеры")] public static float cameraSpeed = 10f;
    [Header("Обычный бекграунд")] public GameObject[] background1 = new GameObject[1];
    [Header("Координаты бека")] public float coordinate = 67.12f;
    [Header("Препятствия")] public GameObject[] obstacles = new GameObject[6];
    [Header("Монетки")] public GameObject money;
    [Header("Счет монет")] public Text moneyScore;
    [Header("Счет дистанции")] public Text distanceScore;
    public static int road, moneyChance;
    public int numObstacles;

    private Vector2 scale;
    private Vector2 position;
    private int sort;
    public static int count = 0;
    public static int distanceCount = 0;
    public static int distanceSpeed = 1;
    public int countCopy = 0;
    private Vector2 scaleMoney;
    private Vector2 positionMoney;
    private Vector2 positionMoneyTop;
    private int randomBG;
    public float yBg = 0f;
    public float ObstTopLine = 4f;
    public float ObstMidLine = 4.5f;
    public float ObstBotLine = 5f;
    public float ObstYTopLine = -1.1f;
    public float ObstYMidLine = -2.7f;
    public float ObstYBotLine = -4.3f;
    public float MonScaleTopLine = 0.15f;
    public float MonScaleMidLine = 0.2f;
    public float MonScaleBotLine = 0.25f;
    public float MonYOneTopLine = 0.9f;
    public float MonYTwoTopLine = 2f;
    public float MonYOneMidLine = -0.7f;
    public float MonYTwoMidLine = 0.4f;
    public float MonYOneBotLine = -2.3f;
    public float MonYTwoBotLine = -1.2f;
    public float PlusMonTwo = 2f;
    private static int countMetr = 0;
    private int randomMusic;
    private bool musicSwap;
    private int musicTime;
    private bool firstBG, twoBG;
    private int krasBgi;

    private List<float> xCoords = new List<float>();

    private void Start()
    {
        count = 0;
        distanceCount = 0;
        distanceSpeed = 1;
        countMetr = 0;
        randomMusic = Random.Range(0, 2);
        musicSwap = true;
        MusicPlay();
        firstBG = false;
        twoBG = false;
        krasBgi = 2;
    }

    void FixedUpdate()
    {
        Debug.Log("RANDOM MUSIC: " + randomMusic);
        if (count < 15)
        {
            distanceSpeed = 1;
        } else if (count >= 15 && count < 30)
        {
            distanceCount = 2;
        }
        else if (count >= 30 && count < 45)
        {
            distanceCount = 3;
        }
        
        if (Money.moneyBool)
        {
            moneyScore.text = count.ToString();
            GetComponent<AudioSource>().Play();
            Money.moneyBool = false;
        }
        
        if (BG_Destroy.destroyBG)
        {
            if (background1.Length == 1)
            {
                Instantiate(background1[0], new Vector2(coordinate, yBg), Quaternion.identity); // создаем бекграунд
            } 
            else if (SceneManager.GetActiveScene().name == "Level_LasVegas")
                {
                    randomBG = Random.Range(0, background1.Length - 1);
                }
                else if (SceneManager.GetActiveScene().name == "Level_School")
                {
                    if (firstBG)
                    {
                        randomBG = 4;
                        firstBG = false;
                        twoBG = true;
                    } 
                    else if (twoBG)
                    {
                        randomBG = 5;
                        twoBG = false;
                    }
                    else
                    {
                        randomBG = Random.Range(0, background1.Length - 2);
                        if (randomBG == 3)
                        {
                            firstBG = true;
                        }
                    }
                } else if (SceneManager.GetActiveScene().name == "Level_Krasnodar")
                {
                    if (krasBgi == 6)
                    {
                        krasBgi = 0;
                    }
                    randomBG = krasBgi;
                    Debug.Log(randomBG);
                }

                Instantiate(background1[randomBG], new Vector2(coordinate, yBg), Quaternion.identity);
                krasBgi++;

            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 1 
            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 2
            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 3

            for (int i = 0; i < 3; i++)
            {
                road = Random.Range(0, 3);
                moneyChance = Random.Range(0, 10);
                switch (road)
                {
                    case 0:
                        scale = new Vector2(ObstTopLine, ObstTopLine);
                        position = new Vector2(xCoords[road], ObstYTopLine);
                        sort = 1;
                        if (moneyChance == 0)
                        {
                            scaleMoney = new Vector2(MonScaleTopLine, MonScaleTopLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneTopLine);
                        }
                        else if (moneyChance == 1)
                        {
                            scaleMoney = new Vector2(MonScaleTopLine,MonScaleTopLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneTopLine);
                            positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoTopLine);
                        }
                        break;
                    case 1:
                        scale = new Vector2(ObstMidLine, ObstMidLine);
                        position = new Vector2(xCoords[road], ObstYMidLine);
                        sort = 3;
                        if (moneyChance == 0)
                        {
                            scaleMoney = new Vector2(MonScaleMidLine,MonScaleMidLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneMidLine);
                        } 
                        else if (moneyChance == 1)
                        {
                            scaleMoney = new Vector2(MonScaleMidLine,MonScaleMidLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneMidLine);
                            positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoMidLine);
                        }
                            break;
                    default:
                        scale = new Vector2(ObstBotLine, ObstBotLine);
                        position = new Vector2(xCoords[road], ObstYBotLine);
                        sort = 5;
                        if (moneyChance == 0)
                        {
                            scaleMoney = new Vector2(MonScaleBotLine,MonScaleBotLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneBotLine);
                        }
                        else if (moneyChance == 1)
                        {
                            scaleMoney = new Vector2(MonScaleBotLine,MonScaleBotLine);
                            positionMoney = new Vector2(xCoords[road], MonYOneBotLine);
                            positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoBotLine);
                        }
                        break;
                }
                GeneratObj(scale, position, sort, moneyChance, scaleMoney, positionMoney, positionMoneyTop, road);
                xCoords[road] = Random.Range(xCoords[road] + 10.66f, xCoords[road] + 15.96f);;
            }

            coordinate += 33.56f;
            BG_Destroy.destroyBG = false;
            xCoords.Clear();
        }
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0);

        if (count == countCopy + 15)
        {
            cameraSpeed += 2;
            countCopy += 15;
            Debug.Log(countCopy);
        }

        countMetr++;
        if (countMetr == 5 && !HeroClassNew.Fail)
        {
            if (HeroClassNew.JumpTwo)
            {
                distanceCount += distanceSpeed * 4;
                distanceScore.text = distanceCount.ToString();
                countMetr = 0; 
            } 
            else if (HeroClassNew.Jump)
            {
                distanceCount += distanceSpeed * 2;
                distanceScore.text = distanceCount.ToString();
                countMetr = 0; 
            }
            else
            {
                distanceCount += distanceSpeed;
                distanceScore.text = distanceCount.ToString();
                countMetr = 0;   
            }
        }
        else if (HeroClassNew.Fail)
        {
            countMetr = 0;
        }

        musicTime++;
        if (musicTime == 5250 && randomMusic == 0)
        {
            randomMusic = 1;
            musicSwap = true;
            
        } else if (musicTime == 5000 && randomMusic == 1)
        {
            randomMusic = 0;
            musicSwap = true;
        }
        Debug.Log("MUSIC TIME" + musicTime);
    }

    void GeneratObj(Vector2 scale, Vector2 position, int sorting, int moneyChance, Vector2 scaleMoney, Vector2 positionMoney, Vector2 positionMoneyTop, int road)
    {
        if (road == 0)
        {
            numObstacles = Random.Range(0, obstacles.Length - 1);
        }
        else
        {
            numObstacles = Random.Range(0, obstacles.Length - 4);   
        }
        obstacles[numObstacles].GetComponent<SpriteRenderer>().sortingOrder = sorting;
        obstacles[numObstacles].transform.localScale = scale;
        Instantiate(obstacles[numObstacles], position, Quaternion.identity);
        if (moneyChance == 0)
        {
            money.GetComponent<SpriteRenderer>().sortingOrder = sorting;
            money.transform.localScale = scaleMoney;
            Instantiate(money, positionMoney, Quaternion.identity);   
        }
        else if (moneyChance == 1)
        {
            money.GetComponent<SpriteRenderer>().sortingOrder = sorting;
            money.transform.localScale = scaleMoney;
            Instantiate(money, positionMoney, Quaternion.identity);
            Instantiate(money, positionMoneyTop, Quaternion.identity);
        }
    }

    void MusicPlay()
    {
        if (randomMusic == 0 && musicSwap)
        {
            GameObject.Find("SoundCxcz").GetComponent<AudioSource>().Play();
            musicSwap = false;
        }
        else if (randomMusic == 1 && musicSwap)
        {
            GameObject.Find("SoundIvan").GetComponent<AudioSource>().Play();
            musicSwap = false;
        }
    }
}
