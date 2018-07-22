using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_hand : MonoBehaviour {

    public Zombie zombie;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            zombie.Attack_player();
    }
}
