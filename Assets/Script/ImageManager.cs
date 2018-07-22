using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour {

    public Sprite AK47;

	public Sprite Get_main_weapon_picture(int number)
    {
        if (number == 0)
            return AK47;
        else
        return null;
    }
}
