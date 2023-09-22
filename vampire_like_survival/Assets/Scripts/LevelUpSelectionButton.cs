using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LevelUpSelectionButton : MonoBehaviour
{

    public TMP_Text upgrade_desc_text, name_level_text;
    public Image weapon_image;
    private Weapon assigned_weapon;

    public void UpdateButtonDisplay(Weapon the_weapon)
    {
        if ( the_weapon.gameObject.activeSelf == true )
        {
            upgrade_desc_text.text = the_weapon.stats[ the_weapon.weapon_level ].upgrade_text;
            weapon_image.sprite = the_weapon.icon;
            name_level_text.text = the_weapon.name + " - Lvl " + the_weapon.weapon_level;
        }
        else
        {
            upgrade_desc_text.text = "Unlock " + the_weapon.name;
            weapon_image.sprite = the_weapon.icon;
            name_level_text.text = the_weapon.name;

        }
        assigned_weapon = the_weapon;

    }
    public void SelectUpgrade()
    {
        if (assigned_weapon != null)
        {
            if(assigned_weapon.gameObject.activeSelf == true ) 
            {
                assigned_weapon.Weapon_level_up();
            }
            else
            {
                PlayerController.instance.AddWeapon( assigned_weapon );    
            }
           
            UIController.Instance.levelup_panel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
