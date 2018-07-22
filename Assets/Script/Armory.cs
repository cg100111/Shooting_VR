using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weapon_Category
{
    main,
    second,
    knife,
    missile
}

public class Armory : MonoBehaviour {

    public GameObject[] weapons_sample;

    private List<Weapon> main_weapons;
    private List<Weapon> secondary_weapons;
    private List<Weapon> knifes;
    private List<Weapon> missile_weapons;

    void Awake()
    {
        main_weapons = new List<Weapon>();
        secondary_weapons = new List<Weapon>();
        knifes = new List<Weapon>();
        missile_weapons = new List<Weapon>();
        //init_pos = new Vector3(0, -1, 0);
        Create();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<Weapon> Get_all_weapon_by_category(int category)
    {
        if (category == (int)Weapon_Category.main)
            return main_weapons;
        else if (category == (int)Weapon_Category.second)
            return secondary_weapons;
        else if (category == (int)Weapon_Category.knife)
            return knifes;
        else if (category == (int)Weapon_Category.missile)
            return missile_weapons;
        else
            return null;
    }

    public void Recycle_weapon(Weapon weapon)
    {
        weapon.transform.parent = this.transform;
        weapon.Modify_position_and_rotation();
    }

    private void Create()
    {
        foreach(GameObject weapon_sample in weapons_sample)
        {
            GameObject weapon = Instantiate(weapon_sample);
            weapon.GetComponent<Weapon>().Initialize();
            weapon.transform.parent = this.transform;
            weapon.GetComponent<Weapon>().Modify_position_and_rotation();
            Classify(weapon.GetComponent<Weapon>());
        }
    }

    private void Classify(Weapon weapon)
    {
        if (weapon.Category == (int)Weapon_Category.main)
            main_weapons.Add(weapon);
        else if (weapon.Category == (int)Weapon_Category.second)
            secondary_weapons.Add(weapon);
        else if (weapon.Category == (int)Weapon_Category.knife)
            knifes.Add(weapon);
        else if (weapon.Category == (int)Weapon_Category.missile)
            missile_weapons.Add(weapon);
    }
}
