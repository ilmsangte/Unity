using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManage : MonoBehaviour
{
    PhotonView PV;//����� ����
    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (PV.IsMine)//�� ���� ��Ʈ��ũ�̸�
        {
            CreateController();//�÷��̾� ��Ʈ�ѷ� �ٿ��ش�. 
        }
    }
    void CreateController()//�÷��̾� ��Ʈ�ѷ� �����
    {
        Debug.Log("Instantiated Player Controller");
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
}
