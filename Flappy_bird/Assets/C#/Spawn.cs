using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [SerializeField] Text score;
    public GameObject pipe, pipe2 ,pipe3;
    float cur_time =0f;
    float cool_down = 2f;
    public float height = 1f;
    bool isPipe2 = false;
    int Pipe_cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_time+=Time.deltaTime;

        if(cur_time>=cool_down){
            cur_time=0;
            if((int.Parse(score.text)+4)%5 ==0 && int.Parse(score.text) !=0 )
            {
                isPipe2 = true;
            }
            int per = Random.Range(0,3);
            if(isPipe2){
                GameObject newPipe = Instantiate(pipe2);
                newPipe.transform.position += new Vector3(0,Random.Range(-height,height),0); 
                Destroy(newPipe,15);
                isPipe2=false;
            }
            else if(Pipe_cnt>=3 && (per == 1 || per ==2 || per==3)){
                GameObject newPipe = Instantiate(pipe3);
                newPipe.transform.position += new Vector3(0,Random.Range(-height,height),0); 
                if(Player.isHard){
                    int r = Random.Range(-20,25);
                    newPipe.transform.rotation = Quaternion.Euler(0,0,r);
                }
                Destroy(newPipe,15);
                Pipe_cnt=0;
            }
            else{
                GameObject newPipe = Instantiate(pipe);
                newPipe.transform.position += new Vector3(0,Random.Range(-height,height),0); 
                if(Player.isHard){
                    int r = Random.Range(-20,25);
                    newPipe.transform.rotation = Quaternion.Euler(0,0,r);
                }
                Destroy(newPipe,15);
            }
            Pipe_cnt+=1;
        }
    }
}
