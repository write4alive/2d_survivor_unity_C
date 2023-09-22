using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponThrower : Weapon
{

    public EnemyDamager enemy_damager;

    private float throw_counter;
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

        throw_counter -= Time.deltaTime;
        if ( throw_counter <= 0 )
        {
            throw_counter = stats[ weapon_level ].attack_speed;

            for( int i = 0; i< stats[weapon_level].amount; i++ ) 
            {

                Instantiate(enemy_damager, enemy_damager.transform.position, enemy_damager.transform.rotation).gameObject.SetActive(true);
   
            }
            SfxManager.instance.PlaySFXPitched(4);
        }
    }

    void SetStats()
    {
        enemy_damager.damage_amounth = stats[ weapon_level ].damage;
        enemy_damager.life_time = stats[ weapon_level ].duration;

        enemy_damager.transform.localScale = Vector3.one * stats[ weapon_level ].range;


        throw_counter = 0f;
    }
}
