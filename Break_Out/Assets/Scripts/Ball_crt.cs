using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_crt : MonoBehaviour
{
    public float BallInitialVelocity = 300f;
    private Rigidbody ballRigidBody = null;

    private void Awake()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        GetComponent<SpriteRenderer>().color = new Color(Resource.Color_r[Resource.idx],Resource.Color_g[Resource.idx],Resource.Color_b[Resource.idx]);
    }
    public void Shoot(){
        transform.parent = null;
        ballRigidBody.isKinematic = false;
        ballRigidBody.AddForce(new Vector3(BallInitialVelocity, -BallInitialVelocity, 0f));
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Block"){
            Destroy(other.gameObject);
            other.transform.GetComponent<Block>().Die();
        }
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Up_wall"){
            ballRigidBody.AddForce(10,-25,0);
        }
    }
}
