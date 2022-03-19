using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] Pannel_Move pannel_Move;
    [SerializeField] Text Score;
    public static int Ball_cnt = 1;
    [SerializeField] GameObject GameOver;
    private void Awake() {
        Ball_cnt = 1;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Ball"){
            Destroy(other.gameObject);
            Ball_cnt --;
        }
        if(Ball_cnt <= 0){
            Resource.coin += pannel_Move.score;
            Score.text = pannel_Move.Score.text;
            GameOver.SetActive(true);
        }
    }
}
