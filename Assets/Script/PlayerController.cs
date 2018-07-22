using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public UIController ui_controller;
    public GameController game_controller;

    private const int MAX_MONEY = 32000;
    private const int MAX_HP = 500;
    private const float MAX_ATTACK = 5.0f;

    private string player_name;
    private float now_max_hp;
    private float now_attack;
    private int money;
    private float hp;

	// Use this for initialization
	void Start () {
        Initialize();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Set_name(string name)
    {
        player_name = name;
    }

    //ダメージを受けた。
    public void Reduce_HP(int damage)
    {
        hp -= damage;
        ui_controller.Update_hp(hp / now_max_hp);
        if (hp <= 0)
            game_controller.Lose_game();
    }

    public bool Add_HP()
    {
        now_max_hp += 20;
        if (now_max_hp > MAX_HP)
        {
            now_max_hp = MAX_HP;
            return false;
        }
        return true;
    }

    public bool Add_attack_plus()
    {
        now_attack += 0.2f;
        if (now_attack > MAX_ATTACK)
        {
            now_attack = MAX_ATTACK;
            return false;
        }
        return true;
    }

    public void Add_money(int price)
    {
        money += price;
        if (money >= MAX_MONEY)
            money = MAX_MONEY;
        ui_controller.Update_money(money.ToString());
    }

    public void Use_money(int price)
    {
        money -= price;
        ui_controller.Update_money(money.ToString());
    }

    public void Reset_HP()
    {
        hp = now_max_hp;
    }

    private void Initialize()
    {
        now_attack = 1.0f;
        now_max_hp = 100;
        Reset_HP();
        money = 100000;
        player_name = "sakusha";
        ui_controller.Update_money(money.ToString());
        ui_controller.Update_hp(hp/now_max_hp);
    }

    public int Money
    {
        get
        {
            return money;
        }
    }

    public float HP
    {
        get
        {
            return now_max_hp;
        }
    }

    public float Attack
    {
        get
        {
            return now_attack;
        }
    }

    public string Name
    {
        get
        {
            return player_name;
        }
    }
}
