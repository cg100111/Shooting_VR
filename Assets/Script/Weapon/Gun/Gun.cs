using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gun : Weapon {
    
    public Transform bulletSpawn;
    public Text info;

    protected int full_bomb_load;
    protected int bullet_price;

    private PlayerController player_controller;
    private BulletObjectPool bullet_objectpool;
    private int now_bomb_load;
    private int now_bullet_count;
    private bool can_fire = true;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    //発射
    public override void Fire()
    {
        if (now_bullet_count > 0 && can_fire)
        {
            //弾丸を生成する
            GameObject bullet = bullet_objectpool.Use(bulletSpawn.position);
            if(bullet != null)
            {
                //威力をつける
                bullet.GetComponent<Bullet>().Damage = (int)(power * player_controller.Attack);
                //スビートを与える
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward * 30;
                now_bullet_count--;
                Update_bomb_load();
                //手を振動させる
                GetComponentInParent<HandController>().Vibrate();
                //エフェクト
                GetComponentInChildren<ParticleSystem>().Play();
                //二秒後、弾丸を自動的にデリートさせる
                bullet.GetComponent<Bullet>().Recycle_after_2second();
                //銃を冷やす
                can_fire = false;
                Invoke("Cool_the_gun", 0.15f);
            }
        }
    }

    //使ている弾丸をチャージする
    public void Change_mag()
    {
        int total = now_bullet_count + now_bomb_load;
        if(total >= full_bomb_load)
        {
            now_bullet_count = full_bomb_load;
            now_bomb_load = total - full_bomb_load;
        }
        else
        {
            now_bullet_count = total;
            now_bomb_load = 0;
        }
        Update_bomb_load();
    }

    //予備の弾丸を増やす
    public int Add_ammunition_load(int money)
    {
        int bullet_quantity = full_bomb_load * 3 - now_bomb_load;
        if (bullet_quantity * bullet_price > money)
            bullet_quantity = money / bullet_price;
        now_bomb_load += bullet_quantity;
        Update_bomb_load();
        return bullet_quantity * bullet_price;
    }

    public Transform Get_bullet_spawn()
    {
        return bulletSpawn;
    }

    public override void Initialize()
    {
        Initialize_data();
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
        bullet_objectpool = GameObject.Find("Bullets").GetComponent<BulletObjectPool>();
        now_bullet_count = full_bomb_load;
        now_bomb_load = 0;
        Update_bomb_load();
        init_position = transform.localPosition;
        init_rotation = transform.localRotation;
    }

    protected abstract void Initialize_data();

    private void Cool_the_gun()
    {
        can_fire = true;
    }

    private void Update_bomb_load()
    {
        info.text = now_bullet_count + " / " + now_bomb_load;
    }
}
