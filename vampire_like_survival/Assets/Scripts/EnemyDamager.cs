using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDamager : MonoBehaviour
{

  
    private const string IS_ENEMY = "Enemy";
    public float damage_amounth, life_time, grow_speed = 5f;
    private Vector3 target_size;
    public bool should_knock_back;
    public bool destroy_parent;
    public bool damage_over_time;
    public float time_between_damage;
    private float damage_counter;

    private List<EnemyController> enemy_in_damager_area = new List<EnemyController>();

    public bool destroy_on_impact;



    // Start is called before the first frame update
    void Start()
    {
       // Destroy(gameObject, life_time);

        target_size = transform.localScale;
        transform.localScale = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, target_size, grow_speed * Time.deltaTime);

        life_time -= Time.deltaTime;    
        if (life_time <= 0 )
        {
            target_size = Vector3.zero;
            if(transform.localScale.x == 0f)
            {
                Destroy(gameObject);

                if( destroy_parent )
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
        if (damage_over_time ==true)
        {
            damage_counter -= Time.deltaTime;

            if(damage_counter <= 0 )
            {
                damage_counter = time_between_damage;

                for (int i = 0;i < enemy_in_damager_area.Count;i++)
                {
                    if(enemy_in_damager_area[i] != null)
                    {
                        enemy_in_damager_area[ i ].TakeDamage(damage_amounth, should_knock_back);
                    }
                    else
                    {
                        enemy_in_damager_area.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( damage_over_time == false )
        {


            if ( collision.tag == IS_ENEMY )
            {
                collision.GetComponent<EnemyController>().TakeDamage(damage_amounth, should_knock_back);

                if (destroy_on_impact)
                {
                    Destroy(gameObject);    
                }
            }
        }
        else
        {
            if(collision.tag == IS_ENEMY )
            {
                enemy_in_damager_area.Add(collision.GetComponent<EnemyController>());

            }
        }

    }
    private void OnTriggerExit2D( Collider2D collision )
    {
         if ( damage_over_time == true )
         {
            if( collision.tag == IS_ENEMY)
            {
                enemy_in_damager_area.Remove(collision.GetComponent<EnemyController>());    
            }
         }
    }
}
