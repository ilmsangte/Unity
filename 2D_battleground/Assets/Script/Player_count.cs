using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_count : MonoBehaviour
{
    public Text Player_cnt;
    private void Update()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        Player_cnt.text = Players.Length.ToString();
    }
}
