using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Pannel_Move pannel_Move;
    Map_Maker map_Maker;
    [SerializeField] GameObject Ball;
    private void Awake() {
        pannel_Move = GameObject.Find("Paddle").GetComponent<Pannel_Move>();
        map_Maker = GameObject.Find("Map_Maker").GetComponent<Map_Maker>();
    }
    void Fun1(){
        Death.Ball_cnt += 1;
        GameObject ball = Instantiate(Ball, transform.position, Quaternion.identity);
        ball.GetComponent<Ball_crt>().Shoot();
    }
    public void Die(){
        if(gameObject.layer == 6){
            Fun1();
        }
        pannel_Move.score += 10;
        Map_Maker.Block_Cnt--;
        pannel_Move.Update_UI();

        if(Map_Maker.Block_Cnt <= 0){
            StartCoroutine(MapMake());
        }
    }
    IEnumerator MapMake(){
        Map_Maker.Block_Cnt = 1;
        yield return new WaitForSeconds(1);
        map_Maker.MakeMap();
    }
}
