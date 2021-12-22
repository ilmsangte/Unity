using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_speed : MonoBehaviour
{
    public float speed=2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
