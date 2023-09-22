using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{

    public static PlayerStatController instance;
    public List<PlayerStatValue> move_speed, health, pickup_range, max_weapons;
    public int move_speed_level_count, health_level_count, pickup_range_count;
    public int move_speed_lvl, health_lvl, pickup_range_lvl, max_weapons_lvl;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() //refactor for loop
    {
        for (int i = move_speed.Count -1 ; i < move_speed_level_count; i++ )
        {
            move_speed.Add(new PlayerStatValue(move_speed[i].cost + move_speed[ 1 ].cost, move_speed[i].value + ( move_speed[1].value - move_speed[0].value)));
        }
        for ( int i = health.Count - 1 ; i < health_level_count ; i++ )
        {
            health.Add(new PlayerStatValue(health[ i ].cost + health[ 1 ].cost, health[ i ].value + ( health[ 1 ].value - health[ 0 ].value )));
        }
        for ( int i = pickup_range.Count - 1 ; i < pickup_range_count ; i++ )
        {
            pickup_range.Add(new PlayerStatValue(pickup_range[ i ].cost + pickup_range[ 1 ].cost, pickup_range[ i ].value + ( pickup_range[ 1 ].value - pickup_range[ 0 ].value )));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.Instance.levelup_panel.activeSelf == true)
        {
            UpdateDisplay();  //!!
        }
    }
    public void UpdateDisplay()  // refactor later
    {
        if( move_speed_lvl < move_speed.Count -1)
        {
            UIController.Instance.move_speed_upgrade_display.UpdateDisplay(move_speed[ move_speed_lvl + 1 ].cost, move_speed[ move_speed_lvl ].value, move_speed[ move_speed_lvl + 1 ].value);
        }
        else
        {
            UIController.Instance.move_speed_upgrade_display.ShowMaxLevel();
        }

        if ( health_lvl < health.Count - 1 )
        {
            UIController.Instance.health_upgrade_display.UpdateDisplay(health[ health_lvl +1 ].cost, health[ health_lvl ].value, health[ health_lvl + 1 ].value);
        }
        else
        {
            UIController.Instance.health_upgrade_display.ShowMaxLevel();
        }

        if ( pickup_range_lvl < pickup_range.Count - 1 )
        {
            UIController.Instance.pickup_upgrade_display.UpdateDisplay(pickup_range[ pickup_range_lvl + 1 ].cost, pickup_range[ pickup_range_lvl ].value, pickup_range[ pickup_range_lvl + 1 ].value);
        }
        else
        {
            UIController.Instance.pickup_upgrade_display.ShowMaxLevel();
        }

        if ( max_weapons_lvl < max_weapons.Count - 1 )
        {
            UIController.Instance.max_weapon_upgrade_display.UpdateDisplay(max_weapons[ max_weapons_lvl + 1 ].cost, max_weapons[ max_weapons_lvl ].value, max_weapons[ max_weapons_lvl + 1 ].value);
        }
        else
        {
            UIController.Instance.max_weapon_upgrade_display.ShowMaxLevel();
        }
    }
    /// <summary>
    // Refactor , generic function ? fakay UI tarafinda objeler uzerinde kod eslemesi yapiliyor bunu incele
    /// </summary>
    public void PurchaseMoveSpeed()
    {
        move_speed_lvl++;
        CoinController.instance.SpendCoin(move_speed[move_speed_lvl].cost);
        UpdateDisplay();

        PlayerController.instance.player_move_speed = move_speed[ move_speed_lvl ].value;
    }
    public void PurchaseHealth()
    {
        health_lvl++;
        CoinController.instance.SpendCoin(health[ health_lvl ].cost);
        UpdateDisplay();

        PlayerHealthController.instance.max_health = health[ health_lvl ].value;
        PlayerHealthController.instance.current_health += health[ health_lvl ].value - health[ health_lvl - 1 ].value;

    }
    public void PurchasePickup()
    {
        pickup_range_lvl++;
        CoinController.instance.SpendCoin(pickup_range[ pickup_range_lvl ].cost);
        UpdateDisplay();

         PlayerController.instance.pickup_range = pickup_range[ pickup_range_lvl ].value;   
    }
    public void PurchaseWeapon()
    {
        max_weapons_lvl++;
        CoinController.instance.SpendCoin(max_weapons[ max_weapons_lvl ].cost);
        UpdateDisplay();

        PlayerController.instance.max_weapons = Mathf.RoundToInt(max_weapons[ max_weapons_lvl ].value);

    }
}

[System.Serializable]
public class PlayerStatValue
{
    public int  cost;
    public float value;

    public PlayerStatValue (int new_cost, float new_value)
    {
        cost = new_cost;
        value = new_value;
    }
}