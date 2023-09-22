using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float move_speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * move_speed * Time.deltaTime;
    }
}
