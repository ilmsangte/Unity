using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Simulation : MonoBehaviour
{
    [SerializeField] Text Collide_time, Impulse, Last_velocity;
    [SerializeField] GameObject Egg, cam;
    [SerializeField] InputField Radius;
    Rigidbody Egg_rgd;
    bool isDrop =false;
    float c=0.47f,p=1.293f,w=0.05f,a=0f,r=0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Egg_rgd = Egg.GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        if(isDrop) {
            var Force = ((Egg_rgd.velocity.y)*(Egg_rgd.velocity.y)*c*p*a)*0.5f;
            Egg_rgd.AddForce(new Vector3(0,Force,0));
        }
        if(r>2){
            cam.transform.position = Egg.transform.position+ new Vector3(0,3f,-10f);    
        }
        else{
            cam.transform.position = Egg.transform.position+ new Vector3(0,1f,-2f);
        }  
    }
    public void Drop(){
        r = float.Parse(Radius.text)+0.02f;
        a = r*r*3.14f;
        w += (((3.14f)*((r*r*r)-(0.000008f)))*4/3)*p;
        Egg.transform.localScale= new Vector3(r*2,r*2,r*2);
        Egg_rgd.mass = w;
        isDrop = true;
        Egg_rgd.useGravity = true;
    }
    public void Restart(){
        Egg_rgd.useGravity = false;
        Egg_rgd.velocity = new Vector3(0,0,0);
        Egg.transform.position = new Vector3(0,7,0);
        Impulse.text = "충격량:";
        Collide_time.text = "필요한 충돌 시간:";
        Last_velocity.text = "끝 속도:";
        r=0;
        a=0;
        w=0.05f;
        Egg.transform.localScale=new Vector3(0.04f,0.04f,0.04f);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ground"){
            Last_velocity.text = "끝 속도: "+Mathf.Abs(Egg_rgd.velocity.y);
            Impulse.text = "충격량: "+Mathf.Abs(Mathf.Round(((Egg_rgd.velocity.y))*w*100000)/100000);
            Collide_time.text = "필요한 충돌 시간: "+Mathf.Round((Mathf.Abs((Egg_rgd.velocity.y*w)/24.75f))*100000)/100000;
            isDrop=false;
        }
    }
}
