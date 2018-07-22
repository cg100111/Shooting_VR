using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatKnife : Knife {

    protected override void Initialize_data()
    {
        price = 2000;
        power = 10;
        category = (int)Weapon_Category.knife;
    }
}
