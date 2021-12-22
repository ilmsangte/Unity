using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit2 : MonoBehaviour
{
    [SerializeField]
    Transform pos;
    [SerializeField]
    float checkRadius;
    [SerializeField]
    LayerMask islayer;

    bool isfruit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isfruit = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);
        if (isfruit == true)
        {
            Destroy(this.gameObject);
        }
    }
}
