using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Gun
{
    protected override void Initialize_data()
    {
        full_bomb_load = 100;
        price = 10000;
        bullet_price = 60;
        power = 60;
        category = (int)Weapon_Category.main;
    }
}
