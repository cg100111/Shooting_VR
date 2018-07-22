using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour {

    public GameObject bullet_prefab;
    public int max_count;

    private List<GameObject> used;
    private List<GameObject> unuse;

    void Awake()
    {
        used = new List<GameObject>();
        unuse = new List<GameObject>();
        Create();
    }

    private void Create()
    {
        for (int num = 0; num < max_count; num++)
        {
            GameObject bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
            unuse.Add(bullet);
        }
    }

    public GameObject Use(Vector3 pos)
    {
        if (unuse.Count > 0)
        {
            unuse[0].SetActive(true);
            unuse[0].transform.position = pos;
            used.Add(unuse[0]);
            unuse.RemoveAt(0);
            return used[used.Count - 1];
        }
        return null;
    }

    public void Unuse_all_enemy()
    {
        while (used.Count > 0)
            Unuse(used[0]);
    }

    public void Unuse(GameObject bullet)
    {
        used.Remove(bullet);
        bullet.SetActive(false);
        bullet.transform.localPosition = bullet_prefab.transform.localPosition;
        unuse.Add(bullet);
    }
}
