using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject background;
    public GameObject shop;
    public Text money_ui;
    public GameObject start;
    public GameObject shop_button;
    public GameObject back;
    public GameObject lose_game;
    public GameObject choose_handedness;
    public GameObject discript;
    public GameObject rank;
    public GameObject rank_button;
    public GameObject Input_name_ui;
    public Image HP;
    public Text timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.D))
        //    Open_shop();
        //if (Input.GetKeyDown(KeyCode.B))
        //    Stop_game();
        //if (Input.GetKeyDown(KeyCode.R))
        //    Rank();
    }

    public void Start_game()
    {
        Set_all_UI_enable(false);
        timer.gameObject.SetActive(true);
        HP.gameObject.SetActive(true);
    }

    public void Stop_game()
    {
        lose_game.GetComponentInChildren<Animator>().SetBool("reset", false);
        Set_all_UI_enable(false);
        background.SetActive(true);
        shop_button.SetActive(true);
        start.SetActive(true);
        rank_button.SetActive(true);
        choose_handedness.SetActive(true);
        discript.SetActive(true);
    }

    public void Lose_game()
    {
        Set_all_UI_enable(false);
        lose_game.SetActive(true);
    }

    public void Rank()
    {
        Set_all_UI_enable(false);
        background.SetActive(true);
        back.SetActive(true);
        rank.SetActive(true);
    }

    public void Input_name()
    {
        Set_all_UI_enable(false);
        background.SetActive(true);
        Input_name_ui.SetActive(true);
    }

    public void Open_shop()
    {
        Set_all_UI_enable(false);
        background.SetActive(true);
        shop.SetActive(true);
        back.SetActive(true);
    }

    public void Update_money(string balance)
    {
        money_ui.text = "使える金額 : " + balance;
    }

    public void Update_time(int time)
    {
        int minute, second;
        minute = time / 60;
        second = time % 60;
        timer.text = minute + " : " + second;
    }

    public void Update_hp(float hp)
    {
        HP.fillAmount = hp;
    }

    private void Set_all_UI_enable(bool enable)
    {
        int child_count = gameObject.transform.childCount;
        for (int child_number = 0; child_number < child_count; child_number++)
            gameObject.transform.GetChild(child_number).gameObject.SetActive(enable);
    }
}
