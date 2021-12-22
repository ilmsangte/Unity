using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;//Room Manager ��ũ��Ʈ�� �޼���� ����ϱ� ���� ����
    void Awake()
    {
        DontDestroyOnLoad(gameObject);//��Ŵ��� ��ȥ�ڸ� �״�� 
        Instance = this;
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        if (scene.buildIndex == 1)//���Ӿ��̸�. 0�� ���� ���۸޴� ���̴�. 
        {
            PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-15,15),Random.Range(-15,15)), Quaternion.identity);
        }
    }
}
