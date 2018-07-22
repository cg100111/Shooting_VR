using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock18c : Gun {
    protected override void Initialize_data()
    {
        full_bomb_load = 10;
        price = 2000;
        bullet_price = 20;
        power = 25;
        category = (int)Weapon_Category.second;
    }
}
