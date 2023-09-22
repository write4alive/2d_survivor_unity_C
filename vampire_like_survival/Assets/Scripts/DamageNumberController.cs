using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;
    public DamageNumber number_to_spawn;
    public Transform number_canvas;

    private List<DamageNumber> number_pool = new List<DamageNumber>();


    private void Awake()
    {
        instance = this;
    }


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            spawn_damage(7f, new Vector3(4 , 3 , 0));  
        }
    }

    public void spawn_damage(float damage_amount, Vector3 location)
    {
        int rounded = Mathf.RoundToInt(damage_amount);

        DamageNumber new_damage =  Instantiate(number_to_spawn, location , Quaternion.identity, number_canvas) ;

        DamageNumber number_to_output = GetFromPool(); 

        new_damage.Setup(rounded);
        new_damage.gameObject.SetActive(true);   

        new_damage.transform.position = location;
    
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber number_to_output = null;

        if(number_pool.Count == 0)
        {
            number_to_output = Instantiate(number_to_spawn, number_canvas);
        }
        else
        {
            number_to_output = number_pool[0];
            number_pool.RemoveAt(0);  
        }

        return number_to_output;
    }

    public void place_in_pool(DamageNumber number_to_place)
    {

        number_to_place.gameObject.SetActive(false);
        number_pool.Add(number_to_place);
    }
}
