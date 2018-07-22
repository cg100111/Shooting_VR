using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4A1 : Gun {

    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 4500;
        bullet_price = 40;
        power = 40;
        category = (int)Weapon_Category.main;
    }
}
