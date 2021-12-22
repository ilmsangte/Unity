using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public PhotonView PV;
    private void Start() => Destroy(gameObject, 3.5f);
    private void Update() => transform.Translate(Vector3.right * 7 * Time.deltaTime);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!PV.IsMine && other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {
            if(this.gameObject.tag == "shotgun_bullet"){
                other.GetComponent<PlayerScript>().HealthImage.fillAmount -= 0.07f;
                PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            }
            else if(this.gameObject.tag == "sniper_bullet"){
                other.GetComponent<PlayerScript>().HealthImage.fillAmount -= 0.5f;
                PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            }
            else{
                other.GetComponent<PlayerScript>().HealthImage.fillAmount -= 0.1f;
                PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
            }
        }
        if(other.tag == "wall"){
            PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);
}
