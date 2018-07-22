using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public EnemyObjectPool object_pool;
    public Transform[] init_positions;

    private bool is_zombie_hp_max;
    private bool is_zombie_attack_max;

	// Use this for initialization
	void Start () {
        is_zombie_attack_max = false;
        is_zombie_hp_max = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_produce()
    {
        InvokeRepeating("Produce", 3f, 3f);
    }

    public void Stop_produce()
    {
        CancelInvoke("Produce");
    }

    public void Recycle_all_enemys()
    {
        object_pool.Unuse_all_enemy();
    }

    public bool Increase_zombie_ability(int which_ability)
    {
        Debug.Log("increase zombie");
        if (is_zombie_hp_max && is_zombie_attack_max)
            return false;
        else if (is_zombie_attack_max)
            Increase_zombie_HP();
        else if (is_zombie_hp_max)
            Increase_zombie_damage();
        else if (which_ability == 0)
            Increase_zombie_HP();
        else if (which_ability == 1)
            Increase_zombie_damage();
        return true;
    }

    private void Increase_zombie_HP()
    {
        foreach (Zombie zombie in object_pool.zombies)
            if (!zombie.Increase_HP())
            {
                is_zombie_hp_max = true;
                break;
            }
    }

    private void Increase_zombie_damage()
    {
        foreach (Zombie zombie in object_pool.zombies)
            if (!zombie.Increase_attack())
            {
                is_zombie_attack_max = true;
                break;
            }
    }

    private void Produce()
    {
        object_pool.Use(init_positions[Get_position_by_random()].position);
    }

    private int Get_position_by_random()
    {
        return Random.Range(0, init_positions.Length);
    }
}
