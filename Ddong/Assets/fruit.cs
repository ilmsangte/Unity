using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPlayer = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        if (isPlayer == true)
        {
            special.Instance.Score2();
            Destroy(this.gameObject);
        }
    }
}
