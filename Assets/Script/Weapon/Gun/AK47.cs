using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun {

    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 4500;
        bullet_price = 40;
        power = 45;
        category = (int)Weapon_Category.main;
    }
}
