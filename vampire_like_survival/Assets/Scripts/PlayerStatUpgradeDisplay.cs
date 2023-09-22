using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatUpgradeDisplay : MonoBehaviour
{

    public TMP_Text value_text, cost_text;

    public GameObject upgrade_button;

    public void UpdateDisplay(int cost, float current_value, float upgraded_value )
    {
        value_text.text = "Value : " + current_value.ToString("F1") + " >> " + upgraded_value.ToString("F1");
        cost_text.text = "Cost : " + cost;


        if (cost  <= CoinController.instance.current_coin)
        {
            upgrade_button.SetActive(true);
        }
        else
        {
            upgrade_button.SetActive(false);    
        }

    }    

    public void ShowMaxLevel()
    {
        value_text.text = "Max Level";
        cost_text.text = "Max Level";
        upgrade_button.SetActive(false);
    }

}
