using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16A1 : Gun
{
    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 4300;
        bullet_price = 40;
        power = 43;
        category = (int)Weapon_Category.main;
    }
}
