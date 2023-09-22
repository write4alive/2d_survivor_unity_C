using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    public static PlayerHealthController instance;

    [SerializeField] public float current_health, max_health;
    public GameObject deathEffect;

    public Slider health_slider;

    private void Awake() {
       instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        max_health = PlayerStatController.instance.health[0].value;
        current_health = max_health;

        health_slider.maxValue = max_health;
        health_slider.value = current_health;
    }

    // Update is called once per frame
    void Update()
    {
        


        // damage by press
        //if (Input.GetKeyDown(KeyCode.T)) {
        //    TakeDamage(10f);
        //}
        
        
    }
    public void TakeDamage(float damage_to_take) {

        current_health -= damage_to_take;

        if (current_health <= 0) {
            gameObject.SetActive(false);

            LevelManager.instance.EndLevel();
            Instantiate(deathEffect, transform.position , transform.rotation);

            SfxManager.instance.PlaySFX(3);
        }

        health_slider.value = current_health;
    }
}
