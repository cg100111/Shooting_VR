using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Knife : Weapon {

    private PlayerController player_controller;
    private bool can_fire;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void Fire()
    {
        can_fire = true;
    }

    public override void Cancel_fire()
    {
        can_fire = false;
    }

    public override void Initialize()
    {
        Initialize_data();
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
        can_fire = false;
        init_rotation = transform.localRotation;
    }

    protected abstract void Initialize_data();

    public int Damage
    {
        get
        {
            if (can_fire)
                return (int)(power * player_controller.Attack);
            else
                return 0;
        }
    }
}
