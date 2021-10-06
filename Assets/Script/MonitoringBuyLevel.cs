using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitoringBuyLevel : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject BuyButton;
    public Text BuySum;
    public GameObject onMus, offMus, tShirt, Zake, ecl2, ecl3;
    public GameObject schoolLogo, krasLogo, lasLogo;

    void FixedUpdate()
    {
        if (ControlScriptForMenu.krasnodarLvl && PlayerPrefs.GetInt("KrasnodarBuy") == 0)
        {
            if (!Buttons.Shop && !Buttons.PromoCodeMenu)
            {
                StartButton.SetActive(false);
                BuyButton.SetActive(true);
                BuySum.text = "10";  
                onMus.SetActive(true);
                tShirt.SetActive(true);
                Zake.SetActive(true);
                krasLogo.SetActive(true);
                ecl2.SetActive(true);
                ecl3.SetActive(true);
            }
        }
        else if (ControlScriptForMenu.lasvegasrLvl && PlayerPrefs.GetInt("LasVegasBuy") == 0)
        {
            if (!Buttons.Shop && !Buttons.PromoCodeMenu)
            {
                StartButton.SetActive(false);
                BuyButton.SetActive(true);
                BuySum.text = "20";   
                onMus.SetActive(true);
                tShirt.SetActive(true);
                Zake.SetActive(true);
                lasLogo.SetActive(true);
                ecl2.SetActive(true);
                ecl3.SetActive(true);
            }
        }
        else
        {
            if (!Buttons.Shop && !Buttons.PromoCodeMenu)
            {
                StartButton.SetActive(true);
                BuyButton.SetActive(false);  
                onMus.SetActive(true);
                tShirt.SetActive(true);
                Zake.SetActive(true);
                schoolLogo.SetActive(true);
                ecl2.SetActive(true);
                ecl3.SetActive(true);
            }
        }
    }
}
