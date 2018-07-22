using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public PlayerController player_controller;
    public UIController ui_controller;
    public EnemyController enemy_controller;
    public RankSystem rank_system;
    [Range(60, 120)]
    public int time_of_one_level = 60;

    private int level;
    private bool is_start;
    private float time;

    // Use this for initialization
    void Start() {
        Initialize();
        ui_controller.Input_name();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.S))
            Start_game();
        if (Input.GetKeyDown(KeyCode.N))
            Input_name();
        if (is_start)
        {
            Count_down();
            if (time < 0)
                Stop_game();
        }
    }

    public void Input_name()
    {
        ui_controller.Input_name();
    }

    public void Start_game()
    {
        is_start = true;
        level++;
        enemy_controller.Start_produce();
        ui_controller.Start_game();
        player_controller.Reset_HP();
    }

    public void Stop_game()
    {
        enemy_controller.Stop_produce();
        enemy_controller.Recycle_all_enemys();
        if (!enemy_controller.Increase_zombie_ability((level + 1) % 2))
            Go_to_rank();
        else
        {
            ui_controller.Stop_game();
            Reset_data();
        }
    }

    public void Lose_game()
    {
        Reset_data();
        enemy_controller.Stop_produce();
        enemy_controller.Recycle_all_enemys();
        ui_controller.Lose_game();
    }

    public void Go_to_rank()
    {
        ui_controller.Rank();
        rank_system.Display_my_record(level);
    }

    public bool Is_start_game()
    {
        return is_start;
    }

    private void Initialize()
    {
        is_start = false;
        level = 0;
        time = time_of_one_level;
    }

    private void Reset_data()
    {
        time = time_of_one_level;
        is_start = false;
        ui_controller.Update_time((int)time);
    }

    private void Count_down()
    {
        time -= Time.deltaTime;
        ui_controller.Update_time((int)time);
    }
}
