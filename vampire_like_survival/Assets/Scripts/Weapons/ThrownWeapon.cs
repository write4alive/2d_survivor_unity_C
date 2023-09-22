using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownWeapon : MonoBehaviour
{

    public float throw_power;
    public Rigidbody2D theRB;
    public float rotate_speed;

    void Start()
    {
        theRB.velocity = new Vector2(Random.Range(-throw_power, throw_power), throw_power); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f,transform.rotation.eulerAngles.z + (rotate_speed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
     
    }


}
