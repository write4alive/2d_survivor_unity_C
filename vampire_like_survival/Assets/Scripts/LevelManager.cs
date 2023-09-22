using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    private bool game_is_active;
    public float timer;
    public float wait_to_show_end_screen = 1.5f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        game_is_active = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (game_is_active == true)
        {
            timer += Time.deltaTime;
            UIController.Instance.UpdateTimer(timer);
        }
    }
    public void EndLevel()
    {
        game_is_active = false;

        StartCoroutine(EndLevelCo());
    }
    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(wait_to_show_end_screen); 

        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60);

        UIController.Instance.end_time_text.text = minutes.ToString() + " mins " + seconds.ToString("00" + " secs");
        UIController.Instance.level_end_screen.SetActive(true);
    }
}
