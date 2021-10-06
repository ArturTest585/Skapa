using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForShop : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        if (gameObject.name == "NameCoinsOff") 
        {
            ShopMenu.indexShopItem = 0;
            Debug.Log(ShopMenu.indexShopItem);
        }
        else if (gameObject.name == "NameTrickOff")
        {
            ShopMenu.indexShopItem = 2;
            Debug.Log(ShopMenu.indexShopItem);
        }
        else if (gameObject.name == "NameSkinsOff")
        {
            ShopMenu.indexShopItem = 1;
            Debug.Log(ShopMenu.indexShopItem);
        }
    }
}
