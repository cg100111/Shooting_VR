using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColtPython : Gun
{
    protected override void Initialize_data()
    {
        full_bomb_load = 6;
        price = 2500;
        bullet_price = 25;
        power = 30;
        category = (int)Weapon_Category.second;
    }
}
