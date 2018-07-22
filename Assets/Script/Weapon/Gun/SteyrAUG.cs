using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteyrAUG : Gun {

    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 4000;
        bullet_price = 35;
        power = 35;
        category = (int)Weapon_Category.main;
    }
}
