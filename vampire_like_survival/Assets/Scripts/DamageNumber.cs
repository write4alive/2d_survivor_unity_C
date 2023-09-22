using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageNumber : MonoBehaviour
{

    public TMP_Text damage_text;
    public float life_time = 0f;
    private float life_counter = 0f;

    public float float_speed = 1f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    life_counter = life_time; 
        
    //}

    // Update is called once per frame
    void Update()
    {
        
        if (life_counter > 0)
        {
            life_counter -= Time.deltaTime;

            if (life_counter <= 0)
            {
                //Destroy(gameObject);
                DamageNumberController.instance.place_in_pool(this);
            }
        }

        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    Setup(10);
        //}
        transform.position += Vector3.up * float_speed * Time.deltaTime;

    }

    public void Setup(int damage_display)
    {
        life_counter = life_time;

        damage_text.text = damage_display.ToString();
    }
}
