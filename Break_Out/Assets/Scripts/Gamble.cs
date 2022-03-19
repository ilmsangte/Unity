using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamble : MonoBehaviour
{
    [SerializeField] ECT_fun ect_Fun;
    [SerializeField] GameObject Color;
    [SerializeField] Image Pick_clr;
    public void Pick(){
        /*if(Resource.coin < 1000){
            return;
        }*/
        Resource.coin -= 1000;
        float r,g,b;
        r = Random.Range(0f,1f); g = Random.Range(0f,1f); b = Random.Range(0f,1f);
        Resource.Color_r.Add(r); Resource.Color_g.Add(g); Resource.Color_b.Add(b);
        Color.GetComponent<Image>().color = new Color(r,g,b);
        ect_Fun.Update_Coin();
    }
    public void Left_arw(){
        Resource.idx -= 1;
        if(Resource.idx < 0){
            Resource.idx = Resource.Color_b.Count - 1;
        }
        Pick_clr.color = new Color(Resource.Color_r[Resource.idx],Resource.Color_g[Resource.idx],Resource.Color_b[Resource.idx]);
    }
    public void Right_arw(){
        Resource.idx += 1;
        if(Resource.idx > Resource.Color_b.Count - 1){
            Resource.idx = 0;
        }
        Pick_clr.color = new Color(Resource.Color_r[Resource.idx],Resource.Color_g[Resource.idx],Resource.Color_b[Resource.idx]);
    }
}
