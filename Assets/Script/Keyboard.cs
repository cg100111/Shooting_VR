using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {

    public InputField player_name;
    public GameObject small_letter_button;
    public GameObject caps_letter_button;
    public GameObject[] first_row_letters;
    public GameObject[] second_row_letters;
    public GameObject[] third_row_letters;

    private const int interval = 12;
    private const int first_row_position_x = -54;
    private const int second_row_position_x = -48;
    private const int third_row_position_x = -36;
    private const int first_row_position_y = 15;

    private GameObject[] letter_button;

    // Use this for initialization
    void Start () {
        Arrange_letters();
        Switch_to_uppercase();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Click_delete()
    {
        if (player_name.text.Length > 0)
            player_name.text = player_name.text.Remove(player_name.text.Length - 1);
    }

    public void Click_Q()
    {
        player_name.text += first_row_letters[0].GetComponentInChildren<Text>().text;
    }

    public void Click_W()
    {
        player_name.text += first_row_letters[1].GetComponentInChildren<Text>().text;
    }

    public void Click_E()
    {
        player_name.text += first_row_letters[2].GetComponentInChildren<Text>().text;
    }

    public void Click_R()
    {
        player_name.text += first_row_letters[3].GetComponentInChildren<Text>().text;
    }

    public void Click_T()
    {
        player_name.text += first_row_letters[4].GetComponentInChildren<Text>().text;
    }

    public void Click_Y()
    {
        player_name.text += first_row_letters[5].GetComponentInChildren<Text>().text;
    }

    public void Click_U()
    {
        player_name.text += first_row_letters[6].GetComponentInChildren<Text>().text;
    }

    public void Click_I()
    {
        player_name.text += first_row_letters[7].GetComponentInChildren<Text>().text;
    }

    public void Click_O()
    {
        player_name.text += first_row_letters[8].GetComponentInChildren<Text>().text;
    }

    public void Click_P()
    {
        player_name.text += first_row_letters[9].GetComponentInChildren<Text>().text;
    }

    public void Click_A()
    {
        player_name.text += second_row_letters[0].GetComponentInChildren<Text>().text;
    }

    public void Click_S()
    {
        player_name.text += second_row_letters[1].GetComponentInChildren<Text>().text;
    }

    public void Click_D()
    {
        player_name.text += second_row_letters[2].GetComponentInChildren<Text>().text;
    }

    public void Click_F()
    {
        player_name.text += second_row_letters[3].GetComponentInChildren<Text>().text;
    }

    public void Click_G()
    {
        player_name.text += second_row_letters[4].GetComponentInChildren<Text>().text;
    }

    public void Click_H()
    {
        player_name.text += second_row_letters[5].GetComponentInChildren<Text>().text;
    }

    public void Click_J()
    {
        player_name.text += second_row_letters[6].GetComponentInChildren<Text>().text;
    }

    public void Click_K()
    {
        player_name.text += second_row_letters[7].GetComponentInChildren<Text>().text;
    }

    public void Click_L()
    {
        player_name.text += second_row_letters[8].GetComponentInChildren<Text>().text;
    }

    public void Click_Z()
    {
        player_name.text += third_row_letters[0].GetComponentInChildren<Text>().text;
    }

    public void Click_X()
    {
        player_name.text += third_row_letters[1].GetComponentInChildren<Text>().text;
    }

    public void Click_C()
    {
        player_name.text += third_row_letters[2].GetComponentInChildren<Text>().text;
    }

    public void Click_V()
    {
        player_name.text += third_row_letters[3].GetComponentInChildren<Text>().text;
    }

    public void Click_B()
    {
        player_name.text += third_row_letters[4].GetComponentInChildren<Text>().text;
    }

    public void Click_N()
    {
        player_name.text += third_row_letters[5].GetComponentInChildren<Text>().text;
    }

    public void Click_M()
    {
        player_name.text += third_row_letters[6].GetComponentInChildren<Text>().text;
    }

    //切換成大寫
    public void Switch_to_uppercase()
    {
        Change_all_letters_to_uppercase();
        small_letter_button.SetActive(true);
        caps_letter_button.SetActive(false);
    }

    //切換成小寫
    public void Switch_to_lowercase()
    {
        Change_all_letters_to_lowercase();
        small_letter_button.SetActive(false);
        caps_letter_button.SetActive(true);
    }

    //把字母換成大寫
    private void Change_all_letters_to_uppercase()
    {
        foreach (GameObject letter in first_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToUpper();
        foreach (GameObject letter in second_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToUpper();
        foreach (GameObject letter in third_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToUpper();
    }

    //把字母換成小寫
    private void Change_all_letters_to_lowercase()
    {
        foreach(GameObject letter in first_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToLower();
        foreach (GameObject letter in second_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToLower();
        foreach (GameObject letter in third_row_letters)
            letter.GetComponentInChildren<Text>().text = letter.GetComponentInChildren<Text>().text.ToLower();
    }

    //排列所有按鍵
    private void Arrange_letters()
    {
        Arrange_first_row_letters();
        Arrange_second_row_letters();
        Arrange_third_row_letters();
    }

    //排列第一排的按鍵
    private void Arrange_first_row_letters()
    {
        Vector3 pos = Vector3.zero;
        for (int count = 0; count < first_row_letters.Length; count++)
        {
            pos.Set(first_row_position_x + interval * count, first_row_position_y, 0);
            first_row_letters[count].transform.localPosition = pos;
        }
    }

    //排列第二排的按鍵
    private void Arrange_second_row_letters()
    {
        Vector3 pos = Vector3.zero;
        for (int count = 0; count < second_row_letters.Length; count++)
        {
            pos.Set(second_row_position_x + interval * count, first_row_position_y - interval, 0);
            second_row_letters[count].transform.localPosition = pos;
        }
    }

    //排列第三排的按鍵
    private void Arrange_third_row_letters()
    {
        Vector3 pos = Vector3.zero;
        for (int count = 0; count < third_row_letters.Length; count++)
        {
            pos.Set(third_row_position_x + interval * count, first_row_position_y - interval * 2, 0);
            third_row_letters[count].transform.localPosition = pos;
        }
    }
}
