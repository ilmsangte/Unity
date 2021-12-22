using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class Watcher : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public Rigidbody2D ply_rgd;
    public float Size = 20;
    Vector3 curPos;

    private void Awake()
    {
        if (PV.IsMine)
        {
            var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
    }
    private void Update()
    {
        if (PV.IsMine)
        {
            float axis1 = Input.GetAxisRaw("Horizontal");
            ply_rgd.velocity = new Vector2(4 * axis1, ply_rgd.velocity.y);
            float axis2 = Input.GetAxisRaw("Vertical");
            ply_rgd.velocity = new Vector2(ply_rgd.velocity.x, 4 * axis2);

            if(gameObject.transform.position.x > Size)
            {
                gameObject.transform.position = new Vector2(Size, gameObject.transform.position.y);
            }
            else if (gameObject.transform.position.x < -Size)
            {
                gameObject.transform.position = new Vector2(-Size, gameObject.transform.position.y);
            }
            if (gameObject.transform.position.y > Size)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x,Size);
            }
            else if (gameObject.transform.position.y < -Size)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x , -Size);
            }
        }
        else if ((transform.position - curPos).sqrMagnitude >= 100)
        {
            transform.position = curPos;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
        }
    }
}
