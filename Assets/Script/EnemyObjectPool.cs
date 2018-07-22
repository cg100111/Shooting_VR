using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour {

    public GameObject zombie_prefab;
    public int max_count;

    private List<Zombie> used;
    private List<Zombie> unuse;

    void Awake()
    {
        used = new List<Zombie>();
        unuse = new List<Zombie>();
        Create();
    }

    private void Create()
    {
        for (int num = 0; num < max_count; num++)
        {
            GameObject enemy = Instantiate(zombie_prefab);
            enemy.transform.parent = this.transform;
            enemy.GetComponent<Zombie>().Initialize();
            enemy.SetActive(false);
            unuse.Add(enemy.GetComponent<Zombie>());
        }
    }

    public void Use(Vector3 position)
    {
        if (unuse.Count > 0)
        {
            unuse[0].gameObject.SetActive(true);
            unuse[0].transform.position = position;
            unuse[0].Start_move();
            used.Add(unuse[0]);
            unuse.RemoveAt(0);
        }
    }

    public void Unuse_all_enemy()
    {
        while (used.Count > 0)
            Unuse(used[0]);
    }

    public void Unuse(Zombie enemy)
    {
        enemy.Stop_move();
        enemy.transform.localPosition = zombie_prefab.transform.localPosition;
        enemy.gameObject.SetActive(false);
        used.Remove(enemy);
        unuse.Add(enemy);
    }

    public List<Zombie> zombies
    {
        get
        {
            return unuse;
        }
    }
}
