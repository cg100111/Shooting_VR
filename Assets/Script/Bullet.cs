using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private BulletObjectPool object_pool;
    private int damage;

	// Use this for initialization
	void Start () {
        object_pool = GameObject.Find("Bullets").GetComponent<BulletObjectPool>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "zombie")
        {
            CancelInvoke("Recycle_myself");
            Recycle_myself();
        }
    }

    public void Recycle_after_2second()
    {
        Invoke("Recycle_myself", 2f);
    }

    private void Recycle_myself()
    {
        object_pool.Unuse(this.gameObject);
    }

    public int Damage
    {
        set
        {
            damage = value;
        }
        get
        {
            return damage;
        }
    }
}
