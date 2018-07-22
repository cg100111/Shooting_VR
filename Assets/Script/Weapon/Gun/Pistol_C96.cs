using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol_C96 : Gun
{
    protected override void Initialize_data()
    {
        full_bomb_load = 15;
        price = 2300;
        bullet_price = 20;
        power = 22;
        category = (int)Weapon_Category.second;
    }
}
