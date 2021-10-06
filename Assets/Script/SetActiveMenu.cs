using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMenu : MonoBehaviour
{
    
    void FixedUpdate()
    {
        if (Buttons.Shop || Buttons.PromoCodeMenu)
        {
            if (gameObject.transform.name == "Skool level name" || gameObject.transform.name == "krasnodar level" ||
                gameObject.transform.name == "Las Vegas Level Name")
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.SetActive(false);   
            }
        }
        else if (!Buttons.Shop || !Buttons.PromoCodeMenu)
        {
            if (gameObject.transform.name == "Skool level name" || gameObject.transform.name == "krasnodar level" ||
                gameObject.transform.name == "Las Vegas Level Name")
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.SetActive(true);   
            }
        }
    }
}
