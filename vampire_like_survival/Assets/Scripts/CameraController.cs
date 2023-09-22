using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform player_target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player_target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void LateUpdate ()
    {
        transform.position = new Vector3(player_target.position.x, player_target.position.y , transform.position.z);
    }
}
