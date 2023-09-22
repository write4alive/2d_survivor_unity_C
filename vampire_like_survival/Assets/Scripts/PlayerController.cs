using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float player_move_speed = 0.7f;

    public Animator player_animator;

    public float pickup_range = 6.5f;

    public List<Weapon> un_assigned_weapons, assigned_weapons;

    public int max_weapons = 3;

    [HideInInspector]
    public List<Weapon> fully_leveled_weapons= new List<Weapon>();

   // public Weapon active_weapon;

    private void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        if ( assigned_weapons.Count == 0 )
        {
            Add_weapon(Random.Range(0, un_assigned_weapons.Count));
        }
        player_move_speed = PlayerStatController.instance.move_speed[ 0 ].value;
        pickup_range = PlayerStatController.instance.pickup_range[ 0 ].value;
        max_weapons =Mathf.RoundToInt(PlayerStatController.instance.max_weapons[ 0 ].value);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move_input = new Vector3(0f, 0f, 0f);

        move_input.x = Input.GetAxisRaw("Horizontal");
        move_input.y = Input.GetAxisRaw("Vertical");

        move_input.Normalize();
       // Debug.Log(move_input);

        if (move_input != Vector3.zero ) {
            player_animator.SetBool("IsMoving",true);
        }
        else {
            player_animator.SetBool("IsMoving", false);
        }


        transform.position += move_input * Time.deltaTime * player_move_speed;
    }

    public void Add_weapon(int weapon_number)
    {
        if ( weapon_number < un_assigned_weapons.Count )
        {
            assigned_weapons.Add(un_assigned_weapons[ weapon_number ]);

            un_assigned_weapons[ weapon_number ].gameObject.SetActive(true);
            un_assigned_weapons.RemoveAt(weapon_number);
        }
    }

    public void AddWeapon(Weapon weapon_to_add) 
    {
        weapon_to_add.gameObject.SetActive(true);

        assigned_weapons.Add(weapon_to_add );

        un_assigned_weapons.Remove(weapon_to_add );
    }
 
}
