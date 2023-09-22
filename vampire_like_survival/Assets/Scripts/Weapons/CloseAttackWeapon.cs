using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{

    public EnemyDamager enemy_damager;
    private float attack_counter, direction;
    private const string IS_HORIZONTAL = "Horizontal";
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
        attack_counter -= Time.deltaTime;

        if( attack_counter <= 0 )
        {
            attack_counter = stats[ weapon_level ].attack_speed;
            direction = Input.GetAxisRaw(IS_HORIZONTAL);

            if ( direction != 0 )
            {
                if( direction > 0)
                {
                    enemy_damager.transform.rotation = Quaternion.identity; 
                }
                else
                {
                    enemy_damager.transform.rotation = Quaternion.Euler(0f, 0f , 180f);
                }

            }

            Instantiate(enemy_damager, enemy_damager.transform.position, enemy_damager.transform.rotation, transform).gameObject.SetActive(true);

            for ( int i = 1 ; i < stats[ weapon_level ].amount ; i++ )
            {
                float sword_rotation = ( 360 / ( stats[ weapon_level ].amount ) ) * i;

                Instantiate(enemy_damager, enemy_damager.transform.position, Quaternion.Euler(0f, 0f, enemy_damager.transform.eulerAngles.z + sword_rotation), transform).gameObject.SetActive(true);
                SfxManager.instance.PlaySFXPitched(9);
            }
        }
    }
    void SetStats()
    {
        enemy_damager.damage_amounth = stats[ weapon_level ].damage;
        enemy_damager.life_time = stats[ weapon_level ].duration;

        enemy_damager.transform.localScale = Vector3.one * stats[ weapon_level ].range;


        attack_counter = 0f;
    } 
}
