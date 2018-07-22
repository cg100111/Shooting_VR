using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class HandController : MonoBehaviour {

    public Armory armory_manager;
    public GameController game_controller;
    public ParticleSystem fire_effect;

    private SteamVR_TrackedObject trackedObj;

    private int now_weapon_number;
    private Weapon[] weapons;

    void Awake()
    {
        weapons = new Weapon[4] { null, null , null , null };
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(weapons[now_weapon_number] != null)
        {
            if (controller.GetHairTrigger() && game_controller.Is_start_game())
                Fire();
            if (controller.GetHairTriggerUp())
                weapons[now_weapon_number].Cancel_fire();
            if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
                Change_mag(); 
        }
        if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            Change_weapon(controller.GetAxis());
    }

    public void Add_weapon(Weapon weapon, int weapon_category)
    {
        if (weapons[now_weapon_number] != null)
            weapons[now_weapon_number].gameObject.SetActive(false);
        if (weapons[weapon_category] != null)
            Delete_weapon(weapons[weapon_category]);
        weapons[weapon_category] = weapon;
        now_weapon_number = weapon_category;
        weapon.transform.parent = this.transform;
        weapon.Modify_position_and_rotation();
        weapon.gameObject.SetActive(true);
        Add_effect_to_the_gun();
    }

    public Weapon Get_using_weapon()
    {
        return weapons[now_weapon_number];
    }

    public void Vibrate()
    {
        controller.TriggerHapticPulse(3000);
    }

    private void Fire()
    {
        weapons[now_weapon_number].Fire();
    }

    private void Change_mag()
    {
        if (weapons[now_weapon_number].Category == (int)Weapon_Category.main || weapons[now_weapon_number].Category == (int)Weapon_Category.second)
            weapons[now_weapon_number].GetComponent<Gun>().Change_mag();
    }

    private void Change_weapon(Vector2 pressed_point)
    {
        Debug.Log(pressed_point);
        if (weapons[now_weapon_number] != null)
            weapons[now_weapon_number].gameObject.SetActive(false);
        if (pressed_point.x >= 0.2f)
            Change_to_next_weapon();
        else if (pressed_point.x <= -0.2f)
            Change_to_previous_weapon();
        if (weapons[now_weapon_number] != null)
        {
            weapons[now_weapon_number].gameObject.SetActive(true);
            Add_effect_to_the_gun();
        }
    }

    private void Change_to_next_weapon()
    {
        now_weapon_number++;
        if (now_weapon_number >= 4)
            now_weapon_number = 0;
    }

    private void Change_to_previous_weapon()
    {
        now_weapon_number--;
        if (now_weapon_number < 0)
            now_weapon_number = 3;
    }

    private void Delete_weapon(Weapon weapon)
    {
        armory_manager.Recycle_weapon(weapon);
    }

    private void Add_effect_to_the_gun()
    {
        if(weapons[now_weapon_number].Category == (int)Weapon_Category.main || weapons[now_weapon_number].Category == (int)Weapon_Category.second)
        {
            fire_effect.transform.parent = weapons[now_weapon_number].transform;
            fire_effect.transform.position = weapons[now_weapon_number].GetComponent<Gun>().Get_bullet_spawn().position;
        }
    }

    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
}
