using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Maker : MonoBehaviour
{
    [SerializeField] GameObject Block;
    [SerializeField] GameObject I_Block;
    public static int Block_Cnt;
    public string[] Map_IDs;
    private void Start() {
        MakeMap();
    }
    void Check_ID(string ID, int num){
        switch (ID){
            case "B":
                GameObject block1 = Instantiate(Block, new Vector3(-2.2f+(1.1f*(num%5)),4.5f-(0.7f*(int)(num/5)),0), Quaternion.identity);
                block1.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
                break;
            case "I":
                Instantiate(I_Block, new Vector3(-2.2f+(1.1f*(num%5)),4.5f-(0.7f*(int)(num/5)),0), Quaternion.identity);
                break;
            case "E":
                break;
        }
    }
    public void MakeMap(){
        string Map_ID = Map_IDs[Random.Range(0,Map_IDs.Length)];
        Block_Cnt = Map_ID.Length;
        for(int i = 0; i<Map_ID.Length; i++){
            Check_ID(Map_ID.Substring(i,1),i);
            if(Map_ID[i] == 'E'){
                Block_Cnt -= 1;
            }
        }
    }
}
