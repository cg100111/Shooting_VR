using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputer : MonoBehaviour {

    public PlayerController player;
    public InputField input;
    public UIController ui_controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Confirm()
    {
        player.Set_name(input.text);
        ui_controller.Stop_game();
    }
}
