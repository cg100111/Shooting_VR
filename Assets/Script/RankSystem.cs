using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour {

    public PlayerController player_controller;
    public ReadWriteFile file_manager;
    public GameObject[] ranking;
    public Text my_record_ui;

    private List<List<string>> contents;
    private string file_name;
    private int my_level;

    void Awake()
    {
        my_level = 0;
        file_name = "rank";
        contents = new List<List<string>>();
    }

	// Use this for initialization
	void Start () {
        Get_rank_info();
        Display_rank();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void Display_my_record(int level)
    {
        my_level = level;
        my_record_ui.text = "おめでとう、" + level + "階までクリア！\n" + Find_order() + "位です";
    }

    public void Record_score()
    {
        int index = Is_there_already_a_record();
        if (index != -1)
            Update_player_record(index);
        else
        {
            Insert_record(Create_new_record());
            file_manager.Write_file(file_name, Transform_to_string());
        }
    }

    private int Find_order()
    {
        foreach(List<string> player_record in contents)
        {
            if (my_level > int.Parse(player_record[1]))
                return contents.IndexOf(player_record);
        }
        return contents.Count + 1;
    }

    private int Is_there_already_a_record()
    {
        foreach (List<string> player_record in contents)
            if (player_record.Contains(player_controller.Name))
                return contents.IndexOf(player_record);
        return -1;
    }

    private void Update_player_record(int index)
    {
        if (int.Parse(contents[index][1]) < my_level)
        {
            contents.RemoveAt(index);
            Insert_record(Create_new_record());
            file_manager.Write_file(file_name, Transform_to_string());
        }
    }

    private List<string> Create_new_record()
    {
        List<string> new_record = new List<string>();
        new_record.Add(player_controller.Name);
        new_record.Add(my_level.ToString());
        return new_record;
    }

    private void Insert_record(List<string> record)
    {
        foreach(List<string> player_record in contents)
        {
            if (int.Parse(record[1]) > int.Parse(player_record[1]))
            {
                contents.Insert(contents.IndexOf(player_record), record);
                return;
            }
        }
        contents.Add(record);
    }

    private void Display_rank()
    {
        for(int order = 0; order < 10; order++)
        {
            if (order < contents.Count)
            {
                ranking[order].SetActive(true);
                for (int number = 0; number < ranking[order].transform.childCount; number++)
                    ranking[order].transform.GetChild(number).GetComponent<Text>().text = contents[order][number];
            }
            else
                ranking[order].SetActive(false);
        }
    }

    private void Get_rank_info()
    {
        Transform(file_manager.Read_file(file_name));
    }

    private void Transform(string[] original_content)
    {
        string[] cutting_flag = new string[] { " ", "　", "  " };
        foreach (string row in original_content)
        {
            string[] info = row.Split(cutting_flag, System.StringSplitOptions.RemoveEmptyEntries);
            contents.Add(new List<string>());
            foreach (string data in info)
                contents[contents.Count - 1].Add(data);
        }
    }

    private string Transform_to_string()
    {
        string new_content = "";
        foreach(List<string> player_record in contents)
        {
            foreach(string data in player_record)
                new_content += (data + " ");
            new_content += "\r\n";
        }
        return new_content;
    }

    public List<List<string>> rank_info
    {
        get
        {
            return contents;
        }
    }
}
