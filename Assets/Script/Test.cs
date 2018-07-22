using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(() => test(5));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void test(int number)
    {
        Debug.Log(number);
    }
}
