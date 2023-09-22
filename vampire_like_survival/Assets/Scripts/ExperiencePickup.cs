using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickup : MonoBehaviour
{

    private const string PLAYER = "Player";
    public int experience_value;
    private bool moving_to_player;
    public float move_speed;
    public float time_between_checks = .2f;
    private float check_counter;

    private PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        player = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving_to_player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, move_speed * Time.deltaTime);
        }
        else
        {
            check_counter -= Time.deltaTime;    

            if(check_counter <= 0)
            {
                check_counter = time_between_checks;
                if(Vector3.Distance(transform.position, player.transform.position) < player.pickup_range)
                {
                    moving_to_player = true;
                    move_speed += player.player_move_speed;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if ( collision.tag == PLAYER ) 
        {
            ExperienceLevelController.instance.GetExp(experience_value);

            Destroy( gameObject );
        }
    }
}
