using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public string ply_state="nom";
    public Text Player_cnt;
    public Rigidbody2D ply_rgd;
    public Animator atr;
    public SpriteRenderer ply_sr;
    public PhotonView PV;
    public Text Nickname;
    public Image HealthImage;
    public Transform gun;
    public GameObject leave,Scope,Sniper,Victory;
    bool is_shot=true;
    CinemachineVirtualCamera CM;
    Vector3 curPos;
    private void Awake()
    {
        if (PV.IsMine)
        {
            CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
            Player_cnt = GameObject.Find("Canvas").transform.Find("player_cnt").GetComponent<Text>();
            Scope = GameObject.Find("Canvas").transform.Find("scope").gameObject;
            Victory = GameObject.Find("Canvas").transform.Find("Victory").gameObject;
            Sniper = GameObject.Find("sniper_cm");
            CM.Follow = transform;
            CM.LookAt = transform;
        }

        Nickname.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
        Nickname.color = PV.IsMine ? Color.green : Color.red;
    }
    private void Update()
    {
        if (PV.IsMine)
        {
            float axis1 = Input.GetAxisRaw("Horizontal");
            ply_rgd.velocity = new Vector2(4 * axis1, ply_rgd.velocity.y);
            float axis2 = Input.GetAxisRaw("Vertical");
            ply_rgd.velocity = new Vector2(ply_rgd.velocity.x, 4 * axis2);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(is_shot){
                    if(ply_state == "shotgun"){
                        StartCoroutine(Shot_check(1));
                        for(int i=0; i<5; i++)
                        {
                            PhotonNetwork.Instantiate("Bullet2", gun.position, Quaternion.Euler(0,0,gun.rotation.eulerAngles.z+(i*5)-10));
                        }
                    }
                    else if(ply_state=="sniper"){
                        StartCoroutine(Shot_check(3));
                        PhotonNetwork.Instantiate("Bullet3", gun.position, gun.rotation);
                    }
                    else{
                        PhotonNetwork.Instantiate("Bullet1", gun.position, gun.rotation);
                    }
                }
            }
            if(HealthImage.fillAmount <= 0)
            {
                PV.RPC("DestroyRPC", RpcTarget.AllBuffered);
                PhotonNetwork.Instantiate("Square2", new Vector3(0,0,0), Quaternion.identity);
                GameObject.Find("Canvas").transform.Find("Leave1").gameObject.SetActive(true);
            }

            if(Player_cnt.text == "1")
            {
                Victory.gameObject.SetActive(true);
            }
            else
            {
                Victory.gameObject.SetActive(false);
            }
            if(Input.GetKey(KeyCode.Mouse1)){
                if(ply_state=="sniper"){
                    Scope.SetActive(true);
                    Sniper.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else{
                Scope.SetActive(false);
            }
        }
        else if((transform.position - curPos).sqrMagnitude >= 100)
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
            stream.SendNext(HealthImage.fillAmount);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
            HealthImage.fillAmount = (float)stream.ReceiveNext();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(PV.IsMine){
            if(other.tag == "Sniper"){
                ply_state = "sniper";
                CM.m_Lens.OrthographicSize = 7;
            }
            else if(other.tag == "shotgun"){
                ply_state="shotgun";
            }
        }
    }
    /*private void OnTriggerStay2D(Collider2D other) {
        if(PV.IsMine){
            if(other.tag == "wall"){
                other.GetComponent<SpriteRenderer>().color = new Color(other.GetComponent<SpriteRenderer>().color.r,other.GetComponent<SpriteRenderer>().color.g,other.GetComponent<SpriteRenderer>().color.b,0);
            }
        }
    }*/
    IEnumerator Shot_check(int time){
        is_shot=false;
        yield return new WaitForSeconds(time);
        is_shot=true;
    }
    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);
}
