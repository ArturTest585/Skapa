using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public static int indexShopItem;
    public Text shopName;
    public GameObject[] menuCoins = new GameObject[3];
    public GameObject[] lenghtItem = new GameObject[5];
    public GameObject[] allTricks = new GameObject[4];
    public GameObject CoinsOn, CoinsOff, TrickOn, TrickOff, SkinsOn, SkinsOff;
    public Text[] price = new Text[4];

    void Start()
    {
        indexShopItem = 0;
    }

    void Update()
    {
        if (indexShopItem == 0)
        {
            // shopName.text = "COINS";
            CoinsOn.SetActive(true);
            CoinsOff.SetActive(false);
            TrickOn.SetActive(false);
            TrickOff.SetActive(true);
            SkinsOn.SetActive(false);
            SkinsOff.SetActive(true);
            
            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(true);
            }

            for (int i = 0; i < 3; i++)
            {
                lenghtItem[i].SetActive(true);
            }

            for (int i = 3; i < 5; i++)
            {
                lenghtItem[i].SetActive(false);
            }
            
            for (int i = 0; i < 3; i++)
            {
                price[i].text = i + ".99$";
            }
            
            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(false);
            }
        }
        else if (indexShopItem == 1)
        {
            // shopName.text = "SKINS";
            CoinsOn.SetActive(false);
            CoinsOff.SetActive(true);
            TrickOn.SetActive(false);
            TrickOff.SetActive(true);
            SkinsOn.SetActive(true);
            SkinsOff.SetActive(false);
            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(false);
            }
            
            for (int i = 0; i < 4; i++)
            {
                lenghtItem[i].SetActive(true);
            }
            
            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(false);
            }
            
            for (int i = 0; i < 3; i++)
            {
                price[i].text = "100";
            }
            price[3].text = "200";
        } 
        else if (indexShopItem == 2)
        {
            // shopName.text = "TRICKS";
            CoinsOn.SetActive(false);
            CoinsOff.SetActive(true);
            TrickOn.SetActive(true);
            TrickOff.SetActive(false);
            SkinsOn.SetActive(false);
            SkinsOff.SetActive(true);
            
            for (int i = 0; i < menuCoins.Length; i++)
            {
                menuCoins[i].SetActive(false);
            }
            
            for (int i = 0; i < 4; i++)
            {
                lenghtItem[i].SetActive(true);
            }
            
            for (int i = 0; i < allTricks.Length; i++)
            {
                allTricks[i].SetActive(true);
            }
            
            for (int i = 0; i < 3; i++)
            {
                price[i].text = "100";
            }
            price[3].text = "200";

            for (int i = 0; i < 4; i++)
            {
                if (i == 0 && PlayerPrefs.GetInt("TrickMethod") == 1 && PlayerPrefs.GetInt("TrickMethodPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Сhoose";
                }
                else if (i == 0 && PlayerPrefs.GetInt("TrickMethod") == 1 && PlayerPrefs.GetInt("TrickMethodPick") == 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Picked";
                }
                else if (i == 0 && PlayerPrefs.GetInt("TrickMethod") != 1 && PlayerPrefs.GetInt("TrickMethodPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "100";   
                }
                
                if (i == 1 && PlayerPrefs.GetInt("TrickNollie") == 1 && PlayerPrefs.GetInt("TrickNolliePick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Сhoose";
                }
                else if (i == 1 && PlayerPrefs.GetInt("TrickNollie") == 1 && PlayerPrefs.GetInt("TrickNolliePick") == 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Picked";
                }
                else if (i == 1 && PlayerPrefs.GetInt("TrickNollie") != 1 && PlayerPrefs.GetInt("TrickNolliePick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "100";   
                }
                
                if (i == 2 && PlayerPrefs.GetInt("TrickNollieFlip") == 1 && PlayerPrefs.GetInt("TrickNollieFlipPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Сhoose";
                }
                else if (i == 2 && PlayerPrefs.GetInt("TrickNollieFlip") == 1 && PlayerPrefs.GetInt("TrickNollieFlipPick") == 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Picked";
                }
                else if (i == 2 && PlayerPrefs.GetInt("TrickNollieFlip") != 1 && PlayerPrefs.GetInt("TrickNollieFlipPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "100";   
                }
                
                if (i == 3 && PlayerPrefs.GetInt("TrickChrist") == 1 && PlayerPrefs.GetInt("TrickChristPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Сhoose";
                }
                else if (i == 3 && PlayerPrefs.GetInt("TrickChristFlip") == 1 && PlayerPrefs.GetInt("TrickChristPick") == 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "Picked";
                }
                else if (i == 3 && PlayerPrefs.GetInt("TrickChristFlip") != 1 && PlayerPrefs.GetInt("TrickChristPick") != 1 && shopName.text == "TRICKS")
                {
                    price[i].text = "200";   
                }
            }
        }
    }
    
}
