using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    private const int MAX_HP = 500;
    private const int MAX_DAMAGE = 50;

    private PlayerController player_controller;
    private EnemyObjectPool enemy_objectpool;
    private Animator animator;
    private Transform player_pos;
    private int money;
    private int HP;
    private int damage;
    private bool is_move;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (is_move)
        {
            //transform.LookAt(new Vector3(player_pos.transform.position.x, 0f, player_pos.transform.position.z));
            transform.Translate(Vector3.forward / 3 * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
            reduce_HP(other.gameObject.GetComponent<Bullet>().Damage);
        if (other.gameObject.tag == "knife")
            reduce_HP(other.gameObject.GetComponent<Knife>().Damage);
        if (other.gameObject.tag == "Player")
            Start_attack();
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
            Stop_attack();
    } 

    public bool Increase_HP()
    {
        if (HP + 50 > MAX_HP)
            return false;
        HP += 50;
        return true;
    }

    public bool Increase_attack()
    {
        if (damage + 5 > MAX_DAMAGE)
            return false;
        damage += 5;
        return true;
    }

    public void Attack_player()
    {
        player_controller.Reduce_HP(damage);
    }

    public void Start_move()
    {
        is_move = true;
        animator.SetBool("is_move", is_move);
    }

    public void Stop_move()
    {
        is_move = false;
        animator.SetBool("is_move", is_move);
    }

    public void Initialize()
    {
        player_controller = GameObject.Find("Player").GetComponent<PlayerController>();
        enemy_objectpool = GameObject.Find("Enemys").GetComponent<EnemyObjectPool>();
        animator = this.GetComponent<Animator>();
        //player_pos = player_controller.transform.FindChild("Camera (eye)").transform;
        Initialize_parameter();
    }

    private void Initialize_parameter()
    {
        HP = 200;
        money = 300;
        damage = 5;
        is_move = false;
    }

    private void reduce_HP(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Recycle_myself();
            player_controller.Add_money(money);
        }
    }

    private void Start_attack()
    {
        animator.SetBool("is_move", false);
        animator.SetBool("attack", true);
    }

    private void Stop_attack()
    {
        animator.SetBool("attack", false);
        animator.SetBool("is_move", true);
    }

    private void Recycle_myself()
    {
        enemy_objectpool.Unuse(this);
    }
}
