using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMP45 : Gun {

    protected override void Initialize_data()
    {
        full_bomb_load = 30;
        price = 4000;
        bullet_price = 30;
        power = 30;
        category = (int)Weapon_Category.main;
    }
}
