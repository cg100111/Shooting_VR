using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : Gun
{
    protected override void Initialize_data()
    {
        full_bomb_load = 7;
        price = 3000;
        bullet_price = 20;
        power = 35;
        category = (int)Weapon_Category.second;
    }
}
