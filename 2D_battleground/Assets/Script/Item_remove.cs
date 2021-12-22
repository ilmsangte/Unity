using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Item_remove : MonoBehaviourPunCallbacks
{
    PhotonView PV;
    private void Awake() {
        PV = gameObject.GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PV.RPC("DestroyRPC",RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);
}
