using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject[] blocks;
    public PlayerController player_controller;
    public HandController right_hand;
    public HandController left_hand;
    public Armory armory_manager;
    public GameObject now_hp;
    public GameObject now_attack;

    private HandController handedness;
    private List<Weapon> now_weapon_category;
    private int total_page;
    private int now_page;

    // Use this for initialization
    void Start() {
        Change_weapon_category(0);
        handedness = right_hand;
    }

    // Update is called once per frame
    void Update() {
    }

    public void Change_weapon_category(int category)
    {
        now_weapon_category = armory_manager.Get_all_weapon_by_category(category);
        Initialize_page();
        Update_weapon_in_shop();
    }

    public void Next_page()
    {
        if (now_page < total_page)
        {
            now_page++;
            Update_weapon_in_shop();
        }
    }

    public void Last_page()
    {
        if (now_page > 1)
        {
            now_page--;
            Update_weapon_in_shop();
        }
    }

    public void Choose_right_hand(bool value)
    {
        if (value)
            handedness = right_hand;
    }

    public void Choose_left_hand(bool value)
    {
        
        if (value)
            handedness = left_hand; 
    }

    public void Buy_weapon_ammunition_load()
    {
        int total_price = 0;
        Weapon using_weapon = handedness.Get_using_weapon();
        if (using_weapon.Category == (int)Weapon_Category.main || using_weapon.Category == (int)Weapon_Category.second)
        {
            total_price = using_weapon.GetComponent<Gun>().Add_ammunition_load(player_controller.Money);
            player_controller.Use_money(total_price);
        }
    }

    private void Buy_weapon(int number)
    {
        Weapon weapon = now_weapon_category[number];
        if (player_controller.Money >= weapon.Price)
        {
            weapon.Initialize();
            player_controller.Use_money(weapon.Price);
            Debug.Log(handedness.name);
            handedness.Add_weapon(weapon, weapon.Category);
        }
    }

    public void Add_player_HP()
    {
        if (!player_controller.Add_HP())
            now_hp.GetComponentInChildren<Button>().enabled = false;
        else
            now_hp.GetComponentInChildren<Text>().text = "今のHP : " + player_controller.HP + " MAX";
    }

    public void Add_player_attack()
    {
        if (!player_controller.Add_attack_plus())
            now_attack.GetComponentInChildren<Button>().enabled = false;
        else
            now_attack.GetComponentInChildren<Text>().text = "今の攻撃 : " + (player_controller.Attack * 100).ToString("0") + " % MAX";
    }

    private void Update_weapon_in_shop()
    {
        Delete_button_onclick_info();
        for (int number = (now_page - 1) * 6; number < now_page * 6; number++)
        {
            if (number < now_weapon_category.Count)
                Set_block_information(number);
            else
                blocks[number % 6].SetActive(false);
        }
    }

    private void Set_block_information(int number)
    {
        blocks[number % 6].SetActive(true);
        blocks[number % 6].transform.GetChild(0).GetComponent<Image>().sprite = now_weapon_category[number].picture;
        blocks[number % 6].transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => Buy_weapon(number));
        blocks[number % 6].transform.GetChild(2).GetComponent<Text>().text = now_weapon_category[number].Price.ToString();
    }

    private void Delete_button_onclick_info()
    {
        foreach (GameObject block in blocks)
            block.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Initialize_page()
    {
        now_page = 1;
        total_page = now_weapon_category.Count / 6;
        if (now_weapon_category.Count % 6 != 0)
            total_page += 1;
    }
}
