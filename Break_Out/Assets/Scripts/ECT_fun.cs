using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ECT_fun : MonoBehaviour
{
    [SerializeField] Text Coin;
    public void Set_false(GameObject obj){
        obj.SetActive(false);
    }
    public void Set_true(GameObject obj){
        obj.SetActive(true);
    }
    public void Loadscene(string Name){
        SceneManager.LoadScene(Name);
    }
    public void Update_Coin(){
        Coin.text = "Coin : "+Resource.coin.ToString();
    }
}
