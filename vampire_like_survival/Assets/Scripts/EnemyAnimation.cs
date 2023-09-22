using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{


    [SerializeField] private Transform enemy_sprite;
    [SerializeField] private float sprite_resize_speed, sprite_min_size, sprite_max_size, sprite_active_size;
    

    // Start is called before the first frame update
    void Start()
    {
        sprite_active_size = sprite_max_size;
        sprite_resize_speed = sprite_resize_speed * Random.Range(0.7f, 1.25f);
    }

    // Update is called once per frame
    void Update() {
        enemy_sprite.localScale = Vector3.MoveTowards(enemy_sprite.localScale, Vector3.one * sprite_active_size, sprite_resize_speed * Time.deltaTime);

        if (enemy_sprite.localScale.x == sprite_active_size) {

            if (sprite_active_size == sprite_max_size) {

                sprite_active_size = sprite_min_size;
            } else {
                sprite_active_size = sprite_max_size;
            }
        }
    }
}
