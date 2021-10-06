using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject mOn,mOff;
    public GameObject[] menuAtribute = new GameObject[6];
    public GameObject shopMenuActive;
    public Text BuyTextLvl;
    public Text MyMoney;
    public int SumBuyLvl;
    public int MyMoneyInt;
    public GameObject StartButton;
    public GameObject BuyButton;
    public static bool Shop = false;
    public static bool PromoCodeMenu = false;
    public GameObject PromoMenu;
    public Text[] ButtonBuy = new Text[4];
    private String buttonName;

    private void Start()
    {
        mOff.SetActive(false);
        mOn.SetActive(true);
        if (PlayerPrefs.GetInt("KrasnodarBuy") != 0 && PlayerPrefs.GetInt("KrasnodarBuy") != 1) PlayerPrefs.SetInt("KrasnodarBuy", 0);
        if (PlayerPrefs.GetInt("LasVegasBuy") != 0 && PlayerPrefs.GetInt("LasVegasBuy") != 1) PlayerPrefs.SetInt("LasVegasBuy", 0);
        SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
        MyMoneyInt = Convert.ToInt32(MyMoney.text);
        Debug.Log(MyMoneyInt);
        Debug.Log(SumBuyLvl);
        Shop = false;
        PromoCodeMenu = false;
        Button back = GetComponent<Button>();
        buttonName = gameObject.AddComponent<Button>().name;
        back.onClick.AddListener(BackGameMenu);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("TrickMethod"));
        // Debug.Log(buttonName);
    }
    

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Start":
                if (ControlScriptForMenu.krasnodarLvl && !Shop) Application.LoadLevel("Level_Krasnodar");
                else if (ControlScriptForMenu.lasvegasrLvl && !Shop) Application.LoadLevel("Level_LasVegas");
                else if (ControlScriptForMenu.schoolLvl && !Shop) Application.LoadLevel("Level_School");
                break;
            case "music_on":
                mOff.SetActive(true);
                mOn.SetActive(false);
                break;
            case "music_off":
                mOff.SetActive(false);
                mOn.SetActive(true);
                break;
            case "Tshirt":
                gameObject.SetActive(false);
                Shop = true;
                shopMenuActive.SetActive(true);
                break;
            case "BuyLevel":
                if (ControlScriptForMenu.krasnodarLvl && !Shop)
                {
                    SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < SumBuyLvl)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - SumBuyLvl;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        StartButton.SetActive(true);
                        BuyButton.SetActive(false);
                        PlayerPrefs.SetInt("KrasnodarBuy", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (ControlScriptForMenu.lasvegasrLvl && !Shop)
                {
                    SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < SumBuyLvl)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - SumBuyLvl;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        StartButton.SetActive(true);
                        BuyButton.SetActive(false);
                        PlayerPrefs.SetInt("LasVegasBuy", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                break;
            case "BackGameMenu":
                Shop = false;
                shopMenuActive.SetActive(false);
                break;
            case "BackShop":
                Shop = true;
                PromoCodeMenu = false;
                PromoMenu.SetActive(false);
                shopMenuActive.SetActive(true);
                break;
            case "PromoCode":
                PromoCodeMenu = true;
                Shop = false;
                shopMenuActive.SetActive(false);
                PromoMenu.SetActive(true);
                break;
            case "Buy1B":
                if (PlayerPrefs.GetInt("TrickMethod") != 1)
                {
                    int price0 = Convert.ToInt32(ButtonBuy[0].text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price0)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price0;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[0].text = "Сhoose";
                        PlayerPrefs.SetInt("TrickMethod", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("TrickMethod") == 1 && PlayerPrefs.GetInt("TrickMethodPick") != 1)
                {
                    PlayerPrefs.SetInt("TrickMethodPick", 1);
                    PlayerPrefs.SetInt("TrickNolliePick", 0);
                    PlayerPrefs.SetInt("TrickNollieFlipPick", 0);
                    PlayerPrefs.SetInt("TrickChristPick", 0);
                    ButtonBuy[0].text = "Picked";
                }
                
                break;
            case "Buy2B":
                if (PlayerPrefs.GetInt("TrickNollie") != 1)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[1].text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[1].text = "Сhoose";
                        PlayerPrefs.SetInt("TrickNollie", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("TrickNollie") == 1 && PlayerPrefs.GetInt("TrickNolliePick") != 1)
                {
                    PlayerPrefs.SetInt("TrickMethodPick", 0);
                    PlayerPrefs.SetInt("TrickNolliePick", 1);
                    PlayerPrefs.SetInt("TrickNollieFlipPick", 0);
                    PlayerPrefs.SetInt("TrickChristPick", 0);
                    ButtonBuy[1].text = "Picked";
                }
                
                break;
            case "Buy3B":
                if (PlayerPrefs.GetInt("TrickNollieFlip") != 1)
                {
                    int price2 = Convert.ToInt32(ButtonBuy[2].text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price2)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price2;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[2].text = "Сhoose";
                        PlayerPrefs.SetInt("TrickNollieFlip", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("TrickNollieFlip") == 1 && PlayerPrefs.GetInt("TrickNollieFlipPick") != 1)
                {
                    PlayerPrefs.SetInt("TrickMethodPick", 0);
                    PlayerPrefs.SetInt("TrickNolliePick", 0);
                    PlayerPrefs.SetInt("TrickNollieFlipPick", 1);
                    PlayerPrefs.SetInt("TrickChristPick", 0);
                    ButtonBuy[2].text = "Picked";
                }
                
                break;
            case "Buy4B":
                if (PlayerPrefs.GetInt("TrickChrist") != 1)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[3].text);
                    MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[3].text = "Сhoose";
                        PlayerPrefs.SetInt("TrickChrist", 1);
                        MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("TrickChrist") == 1 && PlayerPrefs.GetInt("TrickChristPick") != 1)
                {
                    PlayerPrefs.SetInt("TrickMethodPick", 0);
                    PlayerPrefs.SetInt("TrickNolliePick", 0);
                    PlayerPrefs.SetInt("TrickNollieFlipPick", 0);
                    PlayerPrefs.SetInt("TrickChristPick", 1);
                    ButtonBuy[3].text = "Picked";
                }
                
                break;
        }
    }

    void BackGameMenu()
    {
        string nameButton = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(nameButton + "!!!");
        Shop = false;
        shopMenuActive.SetActive(false);
    }
}
