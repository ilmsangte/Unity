using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_scrool : MonoBehaviour
{
    private MeshRenderer render;

    public float speed;
    private float offest;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offest += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offest , 0);
    }
}
