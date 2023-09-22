using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Weapon_stats> stats;
    public int weapon_level;
    public Sprite icon;

    [HideInInspector]
    public bool weapon_stats_updated;

    public void Weapon_level_up()
    {
        if (weapon_level < stats.Count -1) 
        {
            weapon_level++;
            weapon_stats_updated = true;

           
                if(weapon_level >= stats.Count -1)
                {
                    PlayerController.instance.fully_leveled_weapons.Add(this);
                    PlayerController.instance.assigned_weapons.Remove(this);
                }
            
        }
    }
}

[System.Serializable]
public class Weapon_stats
{
    public float speed, damage, range, attack_speed, amount, duration;
    public string upgrade_text;
}
