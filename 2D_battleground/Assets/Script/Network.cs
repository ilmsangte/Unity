using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviourPunCallbacks
{
    public Text Status;
    public InputField NickName, RoomName;
    public GameObject LobbyUI, InRoom, str_button;
    public Text Players;

    private void Awake() => Screen.SetResolution(1920, 1080, false);
    private void Start()
    {
        if(!PhotonNetwork.IsConnected){
            Connect();
        }
    }
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        Status.text = PhotonNetwork.NetworkClientState.ToString();
        if (PhotonNetwork.InRoom)
        {
            LobbyUI.SetActive(false);
            InRoom.SetActive(true);
            PlayersName();
            str_button.SetActive(PhotonNetwork.IsMasterClient);
        }
        else
        {
            LobbyUI.SetActive(true);
            InRoom.SetActive(false);
            Players.text = "방에 있는 플레이어";
        }
    }
    public override void OnConnectedToMaster()
    {
        print("���� ���� �Ϸ�");
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnDisconnected(DisconnectCause cause) => print("���� ����");
    public void JoinLobby() => print("�κ� ���� �Ϸ�");
    public void CreatRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        PhotonNetwork.CreateRoom(RoomName.text, new RoomOptions { MaxPlayers = 5 });
    }
    public void JoinRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        PhotonNetwork.JoinRoom(RoomName.text);
    }
    public void JoinOrCreateRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        PhotonNetwork.JoinOrCreateRoom(RoomName.text, new RoomOptions { MaxPlayers = 5 }, null);
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = NickName.text;
        PhotonNetwork.JoinRandomRoom();
    }
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();
    public override void OnCreatedRoom() => print("방 생성 성공");
    public override void OnJoinedRoom()
    {
        print("참가 성공");
    }
    public override void OnCreateRoomFailed(short returnCode, string message) => print("방 만들기 실패");
    public override void OnJoinRandomFailed(short returnCode, string message) => print("참가 실패");
    public override void OnJoinRoomFailed(short returnCode, string message) => print("참가 실패");
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        str_button.SetActive(PhotonNetwork.IsMasterClient);
    }
    private void PlayersName()
    {
        string Names = "방에 있는 플레이어\n";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Names += PhotonNetwork.PlayerList[i].NickName + "\n";
        }
        Players.text = Names;
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f)), Quaternion.identity);
    }
    public void Game_start(){
        PhotonNetwork.LoadLevel(1);
    }
}
