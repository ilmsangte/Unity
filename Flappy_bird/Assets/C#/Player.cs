using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO; 

//데이터 보관
[System.Serializable] 
public class Data 
{ 
    public List<int> score;
    public List<string> name;
    public List<int> mode;
}
 

public class Player : MonoBehaviour
{
    //데이터 저장용 클레스;
    Data data1 =new Data();
    Data data2 = new Data();
    public static List<int> rank_score = new List<int>(new int[]{0,0,0});
    public static List<string> rank_name = new List<string>(new string[]{"???","???","???"});
    public float power=1;  //점프 파워
    public GameObject pannel;
    public GameObject st;
    public Text text; //랭크 스코어
    int check_sc=5;
    float play_sp = 1f;
    public Text best_score;
    public int isGame=0;
    
    [Header("이름 입력창")]
    public InputField Name; //이름 입력창
    public GameObject input_field;
    public GameObject bullet;
    public GameObject pos;
    public static bool isHard;
    string ply_name;
    bool isBul =true;
    float cur_time=0f,cool_time=3f;
    string filepath;
    int A0,A1;
    Rigidbody2D ply_rgd;

    private void Awake() {
        Time.timeScale = 0f;
        ply_rgd = GetComponent<Rigidbody2D>();
        ply_rgd.gravityScale = 0;

        filepath = Application.persistentDataPath + "/Rankdata.json";

        if(rank_name == null || rank_name.Count ==0){
            rank_name.Add("???");
            rank_score.Add(0);
            rank_name.Add("???");
            rank_score.Add(0);
            rank_name.Add("???");
            rank_score.Add(0);
        }
        load();
        isHard=false;
    }
    private void Start() {
    }
    // Update is called once per frame
    void Update()
    {
                /*
                string Ard_input = Serial.ReadLine();
                char a1 = Ard_input[0];
                char a2 = Ard_input[1];
                A0 = (int)a1-(int)'0';
                A1 = (int)a2-(int)'0';
                */

                if(isGame==0 || A0==1 || A1 ==1){
                    if(Input.GetKeyDown(KeyCode.Space) || A0 >= 700){
                        isGame+=1;
                        St();
                    }
                }
                if (isGame >= 1) {
                    cur_time+=Time.deltaTime;
                    if(cur_time>=cool_time){
                        cur_time=0;
                        isBul=true;
                    }
                    if(Input.GetKeyDown(KeyCode.Space)|| A0==1 || A1 ==1){
                        ply_rgd.velocity = Vector2.up * power;
                    }
                    if(int.Parse(text.text)>=check_sc){
                        play_sp += 0.1f;
                        Time.timeScale = play_sp;
                        check_sc +=2;
                        power+=0.03f;
                    }
                    if(Input.GetMouseButtonDown(0) && isBul){ 
                        GameObject bul = Instantiate(bullet);
                        bul.transform.position = pos.transform.position;
                        Destroy(bul,4);
                        isBul=false;
                    }
                }
                if(Input.GetKeyDown(KeyCode.Escape)){
                    Application.Quit();
                } 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "ground"){
            Time.timeScale = 0f;
            pannel.SetActive(true);

            if(Load.Mode == 2){
                PlayerPrefs.SetInt("Score",int.Parse(text.text));
                PlayerPrefs.SetString("Name","최근 기록:"+ text.text);
                //랭크 원소 추가
                if(int.Parse(text.text) > rank_score[0]){
                    print("1등 저장");
                    rank_score.Insert(0,int.Parse(text.text));
                    rank_name.Insert(0,ply_name);
                }
                else if(int.Parse(text.text) > rank_score[1]){
                    print("2등 저장");
                    rank_score.Insert(1,int.Parse(text.text));
                    rank_name.Insert(1,ply_name);
                }
                else if(int.Parse(text.text) > rank_score[2]){
                    print("3등 저장");
                    rank_score.Insert(2,int.Parse(text.text));
                    rank_name.Insert(2,ply_name);
                }
                else{
                    print("4등 저장");
                }

                if(rank_score.Count>3){
                    rank_score.RemoveAt(3);
                    rank_name.RemoveAt(3);
                }
                data1.name = rank_name;
                data1.score = rank_score;

                File.WriteAllText(filepath, JsonUtility.ToJson(data1));
            }

            isGame =-1;
        }
    }

    public void click(){
        pannel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("play");
    }

    public void St(){
        if(Name.text==""){
            ply_name="기본플레이어";
        }
        else if(Name.text =="기본"){
            text.text ="10";
        }
        else if(Name.text == "extreme" || Name.text == "extreme "){
            isHard=true;
        }
        else
        { 
            ply_name = Name.text; 
        }
        Time.timeScale = 1f;
        st.SetActive(false);
        input_field.SetActive(false);
        best_score.text = PlayerPrefs.GetString("Name");
        ply_rgd.gravityScale = 1f;
    }

    public void load(){
        print(File.Exists(filepath));
        if (File.Exists(filepath)){
            string str2 = File.ReadAllText(filepath); 
            data2 = JsonUtility.FromJson<Data>(str2);

            rank_name = data2.name;
            rank_score = data2.score;
        }
        else{
            print("랭크 새로 생성");
        }
    }
}
