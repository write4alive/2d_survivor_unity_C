using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody2D enemy_rigidbody;
    public float enemy_speed;
    private Transform target;
    private const string PLAYER_TAG = "Player";
    
    public float damage;

    public float hit_wait_time = 1f;
    private float hit_counter;
    public float health = 5f;

    public float knock_back_time = .5f;
    private float knock_back_counter;

    public bool should_knock_back;

    public int experience_to_give = 20;

    public int coin_value = 1;
    public float coin_drop_rate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform; 
        // boyle yaptim cunku oyuncu olunce direk null referance hatasi veriyordu haliyle bulamadigi icin. fakat boyle olunca hata verdirmiyoruz. 
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null) {
            target = playerController.transform;
        } 
        /*else {
            Debug.LogError("bulunamad !");
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        if ( PlayerController.instance.gameObject.activeSelf == true )
        {
            if ( knock_back_counter > 0 )
            {
                knock_back_counter -= Time.deltaTime;
                if ( enemy_speed > 0 )
                {
                    enemy_speed = -enemy_speed * 2f;
                }
                if ( knock_back_counter <= 0 )
                {
                    enemy_speed = Mathf.Abs(enemy_speed * .5f);
                }
            }


            if ( target != null )
            {
                enemy_rigidbody.velocity = ( target.position - transform.position ).normalized * enemy_speed;
            }

            // enemy_rigidbody.velocity = (target.position - transform.position).normalized * enemy_speed;

            if ( hit_counter > 0f )
            {
                hit_counter -= Time.deltaTime;
            }

        }
        else
        {
            enemy_rigidbody.velocity = Vector2.zero;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
       if (collision.gameObject.tag == PLAYER_TAG && hit_counter <= 0f) {
            PlayerHealthController.instance.TakeDamage(damage);
            hit_counter = hit_wait_time;

        }
    } 
    public void TakeDamage (float damage_to_take)
    {
        health -= damage_to_take;
        if (health <= 0) 
        { 
            Destroy(gameObject);
            ExperienceLevelController.instance.spawn_exp(transform.position, experience_to_give);

            if (Random.value <= coin_drop_rate)
            {
                CoinController.instance.Drop_Coin(transform.position, coin_value);
            }
            //enemy death
            SfxManager.instance.PlaySFXPitched(0);

        }
        else
        {
            //enem hit
            SfxManager.instance.PlaySFXPitched(1);
        }

        DamageNumberController.instance.spawn_damage(damage_to_take, transform.position);

    }

    public void TakeDamage(float damage_to_take, bool should_knock_back)
    {
        TakeDamage(damage_to_take);

        if (should_knock_back == true)
        {
            knock_back_counter = knock_back_time;
        }

    }

}
