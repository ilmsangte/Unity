using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviourPunCallbacks
{
    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        Destroy(GameObject.Find("RoomManager").gameObject);
        SceneManager.LoadScene("Lobby");
    }
}
