using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    string filepath;
    Data data2;
    [SerializeField] Text[] Rank_name = new Text[3], Rank_score = new Text[3];
    public static List<int> rank_score = new List<int>(new int[]{0,0,0});
    public static List<string> rank_name = new List<string>(new string[]{"???","???","???"});


    private void Start() {
        filepath = Application.persistentDataPath + "/Rankdata.json";
        print(File.Exists(filepath));
        if (File.Exists(filepath)){
            string str2 = File.ReadAllText(filepath); 
            data2 = JsonUtility.FromJson<Data>(str2);

            rank_name = data2.name;
            rank_score = data2.score;

            for(int i=0; i<rank_name.Count;i++){
                Rank_name[i].text = rank_name[i];
                Rank_score[i].text = rank_score[i].ToString();
                if(Rank_name[i].text == "extreme" || Rank_name[i].text == "extreme "){
                    Rank_name[i].color = new Color(1,0,0);
                }
            }
        }
    }
    
    /*
    void Update()
    {
        for(int i=0; i<3; i++){
            Rank_name[i].text = Player.rank_name[i];
            Rank_score[i].text = Player.rank_score[i].ToString();
        }
    }*/
}
