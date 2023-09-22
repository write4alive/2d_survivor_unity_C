using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAroundPlayer : Weapon
{
    public float rotation_speed;
    public Transform holder, fireball_to_spawn;

    public float time_between_spawn;
    private float spawn_counter;

    public EnemyDamager damager;

    // Start is called before the first frame update
    void Start()
    {
        Set_stats();
        //UIController.Instance.level_up_buttons[ 0 ].UpdateButtonDisplay(this);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(new Vector3(0f, Time.time * 30f, 0f));
        // holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + ((rotation_speed * Time.deltaTime)));
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + ( ( rotation_speed * Time.deltaTime * stats[weapon_level].speed ) ));
        spawn_counter -= Time.deltaTime;

        if (spawn_counter < 0)
        {
            spawn_counter = time_between_spawn;
            //Instantiate(fireball_to_spawn, fireball_to_spawn.position, fireball_to_spawn.rotation, holder).gameObject.SetActive(true);

            for (int i = 0; i < stats[weapon_level].amount; i++) 
            {
                float spin_rotation_angle = (360 / ( stats[weapon_level].amount ))* i;

                Instantiate(fireball_to_spawn, fireball_to_spawn.position, Quaternion.Euler(0f, 0f, spin_rotation_angle), holder).gameObject.SetActive(true);
                SfxManager.instance.PlaySFX(8);
            }

        }
        if(weapon_stats_updated == true )
        {
            weapon_stats_updated = false;
            Set_stats();
        }
    }
    public void Set_stats()
    {
        damager.damage_amounth = stats[ weapon_level ].damage;

        transform.localScale = Vector3.one * stats[ weapon_level ].range;

        time_between_spawn = stats[ weapon_level ].attack_speed;

        damager.life_time = stats[ weapon_level ].duration;

        spawn_counter = 0f;


    }
}
