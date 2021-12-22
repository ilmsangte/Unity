using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_speed2 : MonoBehaviour
{
    public float speed=2f;
    float rise_inc = 1;

    // Start is called before the first frame update
    void Start()
    {       
        rise_inc = Random.Range(-1,1);
        if(rise_inc>=0){
            rise_inc = 1f;
        }
        else
        {
            rise_inc = -1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        gameObject.transform.position += new Vector3 (0,rise_inc,0) *Time.deltaTime*1.5f;
        if(gameObject.transform.position.y>=3f){
            rise_inc = -1;
        }
        else if(gameObject.transform.position.y <=-1.5){
            rise_inc = 1;
        }
    }
}
