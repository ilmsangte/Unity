using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Map_make : MonoBehaviourPunCallbacks
{
    bool is_spawn =true;
    string[] gun_name = new string[2]{"sniper","shotgun"};
    private void Update() {
        if(is_spawn){
            StartCoroutine(Sniper_spawn());
        }
    }
    IEnumerator Sniper_spawn(){
        is_spawn = false;
        int i = Random.Range(0,2);
        print(i);
        PhotonNetwork.Instantiate(gun_name[i],new Vector2(Random.Range(-19,19),Random.Range(-19,19)),Quaternion.identity);
        yield return new WaitForSeconds(30);
        is_spawn = true;
    }
}
