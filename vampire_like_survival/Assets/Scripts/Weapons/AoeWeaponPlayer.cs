using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeWeaponPlayer : Weapon
{

    public EnemyDamager enemy_damager;
    private float spawn_time, spawn_counter;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        if ( weapon_stats_updated == true )
        {
            weapon_stats_updated = false;
            SetStats();
        }

        spawn_counter -= Time.deltaTime;  
        if( spawn_counter <= 0f )
        {
            spawn_counter = spawn_time;
            Instantiate(enemy_damager, enemy_damager.transform.position, Quaternion.identity, transform ).gameObject.SetActive(true);
            SfxManager.instance.PlaySFXPitched(10);
        }

    }

     void SetStats()
    {
        enemy_damager.damage_amounth = stats[ weapon_level ].damage;
        enemy_damager.life_time = stats[ weapon_level ].duration;

        enemy_damager.time_between_damage = stats[ weapon_level ].speed;

        enemy_damager.transform.localScale = Vector3.one * stats[ weapon_level ].range;

        spawn_time = stats[ weapon_level ].attack_speed;

        spawn_counter = 0f;
    }
}
