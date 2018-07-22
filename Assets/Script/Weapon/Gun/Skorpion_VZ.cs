using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skorpion_VZ : Gun {

    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 3700;
        bullet_price = 30;
        power = 35;
        category = (int)Weapon_Category.main;
    }
}
