using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public Sprite picture;

    protected int price;
    protected int power;
    protected int category;
    protected Vector3 init_position;
    protected Quaternion init_rotation;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Modify_position_and_rotation()
    {
        transform.localPosition = init_position;
        transform.localRotation = init_rotation;
    }

    public abstract void Fire();

    public virtual void Cancel_fire() { }

    public abstract void Initialize();

    public int Price
    {
        get
        {
            return price;
        }
    }

    public int Category
    {
        get
        {
            return category;
        }
    }
}
