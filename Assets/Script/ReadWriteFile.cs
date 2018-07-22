using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWriteFile : MonoBehaviour {

    private string path;

    void Awake()
    {
        path = Application.streamingAssetsPath + "/Resources/";
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Write_file(string file_name,string content)
    {
        string new_path = path + file_name + ".txt";
        File.WriteAllText(new_path, content);
    }

    public string[] Read_file(string file_name)
    {
        string new_path = path + file_name + ".txt";
        string txt = File.ReadAllText(new_path);
        return txt.Split(new string[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
    }
}
