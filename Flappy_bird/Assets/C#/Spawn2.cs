using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn2 : MonoBehaviour
{
    [SerializeField] Text score;
    public GameObject pannel;
    public GameObject pipe,pipe3;
    float cur_time =0f;
    float cool_down = 2f;
    public float height = 1f;
    int Pipe_cnt = 0;

    // Update is called once per frame
    void Update()
    {
        cur_time+=Time.deltaTime;

        if(cur_time>=cool_down){
            cur_time=0;

            int per = Random.Range(0,3);
            
            if(Pipe_cnt>=3 && (per == 1 || per ==2)){
                GameObject newPipe = Instantiate(pipe3);
                newPipe.transform.position += new Vector3(0,Random.Range(-height,height),0); 
                Destroy(newPipe,15);
                Pipe_cnt=0;
            }
            else{
                GameObject newPipe = Instantiate(pipe);
                newPipe.transform.position += new Vector3(0,Random.Range(-height,height),0); 
                Destroy(newPipe,15);
            }
            Pipe_cnt+=1;
        }
    }

    public void Restart2(){
        pannel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("play_easy");
    }
}
