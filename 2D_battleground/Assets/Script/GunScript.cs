using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GunScript : MonoBehaviourPunCallbacks
{
    public Transform trans;
    public PhotonView PV;
    // Update is called once per frame
    void Update()
    {
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 Scope_vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        if (PV.IsMine)
        {
            transform.rotation = Quaternion.Euler(0, 0, z);
            transform.localPosition = new Vector2(Mathf.Cos(z * Mathf.Deg2Rad) *0.5f, Mathf.Sin(z * Mathf.Deg2Rad)*0.5f);
        }
    }
}
