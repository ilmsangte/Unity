using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pannel_Move : MonoBehaviour
{
    public ulong score = 0;
    [SerializeField] float PaddleSpeed = 1f;
    [SerializeField] public Text Score;
    private Vector3 playerPos;
    float xPos = 0;
    bool isLeft, isRight;
    private void Start() {
        playerPos = transform.position;
    }

    private void Update()
    {
        xPos = transform.position.x + (Input.GetAxis("Horizontal") * PaddleSpeed);
        if(isLeft){
            xPos = transform.position.x + (-1 * PaddleSpeed);
        }
        else if(isRight){
            xPos = transform.position.x + (PaddleSpeed);
        }

        playerPos = new Vector3(Mathf.Clamp(xPos, -2.5f, 2.5f), playerPos.y, 0f);
        transform.position = playerPos;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ball"){
            float X_axis = other.transform.position.x - transform.position.x;
            int X = 0;
            if(X_axis > 0){
                X = 1;
            }
            else if(X_axis<0){
                X = -1;
            }
            other.rigidbody.AddForce(new Vector3(X*50,150,0));
        }
    }
    public void Update_UI(){
        Score.text = "Score : "+score.ToString();
    }
    public void click_down(int axis){
        switch (axis){
            case -1:
                isLeft = true;
                isRight = false;
                break;
            case 1:
                isLeft = false;
                isRight = true;
                break;
        }
    }
    public void click_up(){
        isLeft = false;
        isRight = false;
    }
}
