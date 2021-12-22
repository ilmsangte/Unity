using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit3 : MonoBehaviour
{
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    bool isGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        if (isGround == true)
        {
            Destroy(this.gameObject);
        }
    }
}
