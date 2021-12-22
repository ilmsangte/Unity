using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{

    public static int Mode;
    public void Load_hard(){
        SceneManager.LoadScene("play");
        Mode = 2;
    }
    public void Load_easy(){
        SceneManager.LoadScene("play_easy");
        Mode = 1;
    }

    public void Load_menu(){
        Time.timeScale=1f;
        SceneManager.LoadScene("menu");
    }
}
