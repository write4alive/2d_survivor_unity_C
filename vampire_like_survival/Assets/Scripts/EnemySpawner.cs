using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy_to_spawn;

    public float time_to_spawn;
    private float spawn_counter;

    public Transform min_spawn, max_spawn;

    private Transform target;
    private float despawn_distance;

    private List<GameObject> spawned_enemies = new List<GameObject>();

    public int check_per_frame;
    private int enemy_to_check;

    public List<WaveInfo> enemy_waves;

    private int current_wave;
    private float wave_counter;
    
    // Start is called before the first frame update
    void Start()
    {
       // spawn_counter = time_to_spawn;

        target = PlayerHealthController.instance.transform;

        despawn_distance = Vector3.Distance(transform.position,max_spawn.position) + 4f;

        current_wave = -1;
        go_to_next_wave();
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerHealthController.instance.gameObject.activeSelf) {

               if(current_wave < enemy_waves.Count) {
                    wave_counter -= Time.deltaTime;

                    if(wave_counter <- 0 )
                    {
                        go_to_next_wave();
                    }

                    spawn_counter -= Time.deltaTime;

                    if(spawn_counter <= 0 )
                    {
                        spawn_counter = enemy_waves[current_wave].time_between_spawns; 
                        GameObject new_enemy = Instantiate(enemy_waves[current_wave].enemy_to_spawn, SelectSpawnPoint(),Quaternion.identity);

                        spawned_enemies.Add(new_enemy); 
                    }
            }
        }

        //spawn_counter -= Time.deltaTime;

        //if(spawn_counter <= 0) {

        //    spawn_counter = time_to_spawn;

        //    //Instantiate(enemy_to_spawn, transform.position, transform.rotation);

        //    GameObject new_enemy = Instantiate(enemy_to_spawn,SelectSpawnPoint() ,transform.rotation);
        //    spawned_enemies.Add(new_enemy);

        //}

        transform.position = target.position;

        int check_target = enemy_to_check + check_per_frame;

        while (enemy_to_check < check_target) {
            if (enemy_to_check < spawned_enemies.Count) {

                if (spawned_enemies[enemy_to_check] != null) {

                    if (Vector3.Distance(transform.position, spawned_enemies[enemy_to_check].transform.position) > despawn_distance) {
                        Destroy(spawned_enemies[enemy_to_check]);

                        spawned_enemies.RemoveAt(enemy_to_check);
                        check_target--;
                    } else {
                        enemy_to_check++;
                    }
                } else {

                    spawned_enemies.RemoveAt(enemy_to_check);
                    check_target--;
                }
            }
            else 
            {
                enemy_to_check = 0;
                check_target = 0;
            }
        }

    }
    public Vector3 SelectSpawnPoint( ) {
        bool spawn_vertical_edge = Random.Range(0f, 1f) >.5f;

        Vector3 spawnPoint = Vector3.zero;

        if ( spawn_vertical_edge ) {
            spawnPoint.y = Random.Range(min_spawn.position.y, max_spawn.position.y);
            
            if(Random.Range(0f ,1f ) > .5f) {
                spawnPoint.x = max_spawn.position.x;
            } else {
                spawnPoint.x = min_spawn.position.x;    
            }
        } else {
            spawnPoint.x = Random.Range(min_spawn.position.x, max_spawn.position.x);
            if (Random.Range(0f, 1f) > .5f) {
                spawnPoint.y = max_spawn.position.y;
            } else {
                spawnPoint.y = min_spawn.position.y;
            }
        }
       
        return spawnPoint;
    }

    public void go_to_next_wave()
    {
        current_wave++;

        if ( current_wave >= enemy_waves.Count )
        {
            current_wave = enemy_waves.Count - 1;
        }
        wave_counter = enemy_waves[ current_wave ].wave_len;
        spawn_counter = enemy_waves[ current_wave ].time_between_spawns;
    }
}

[System.Serializable]
public class WaveInfo
{
    public GameObject enemy_to_spawn;
    public float wave_len = 10f;
    public float time_between_spawns = 10f;
}