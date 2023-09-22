using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;//baska nesnelerden bu instance'a direk erisim acik hale geliyor.
    public Slider experince_level_slider;
    public TMP_Text experince_level_text;
    public LevelUpSelectionButton[] level_up_buttons;
    public GameObject levelup_panel;
    public TMP_Text coin_text;
    public PlayerStatUpgradeDisplay move_speed_upgrade_display, health_upgrade_display, pickup_upgrade_display, max_weapon_upgrade_display;
    public TMP_Text time_text;
    private const string COIN_TEXT = "Coins : ";
    public GameObject level_end_screen;
    public TMP_Text end_time_text;
    public string main_menu_name;
    public GameObject pause_screen;

    private void Awake()
    {
        Instance = this;  
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();

        }
    }
    public void Update_experince_level(int  current_exp, int level_exp, int current_level)
    {
        experince_level_slider.maxValue = level_exp;
        experince_level_slider.value = current_exp;
        experince_level_text.text = "Level - " + current_level; 
    }

    public void skip_level_up()
    {
        levelup_panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Update_Coins()
    {
        coin_text.text = COIN_TEXT + CoinController.instance.current_coin;
    }
    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        skip_level_up();
    }
    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        skip_level_up();
    }
    public void PurchasePickup()
    {
        PlayerStatController.instance.PurchasePickup();
        skip_level_up();
    }
    public void PurchaseWeapon()
    {
        PlayerStatController.instance.PurchaseWeapon();
        skip_level_up();
    } 
    public void UpdateTimer(float time)
    {
        //refactor  same logic at level_manager
        float minutes = Mathf.FloorToInt( time / 60f);
        float seconds = Mathf.FloorToInt(time % 60);
        time_text.text = "Time :" + minutes + ":" + seconds.ToString("00");
    }
    public void Go_to_main_menu()
    {
        SceneManager.LoadScene(main_menu_name);
        Time.timeScale = 1f;
    }
    public void Restard_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGamne()
    {
        Application.Quit(); 

    }

    public void PauseUnpause()
    {
        if ( pause_screen.activeSelf == false)
        {
            pause_screen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {

            pause_screen.SetActive(false);
            if(levelup_panel.activeSelf == false)
            {
                Time.timeScale = 1f;

            }
        }
        
    }
}
