using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWMAIN : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private Animator animator;

    private SpriteRenderer renderer;

    private float speed = 3;

    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        PlayerMove();
    }

    private void PlayerMove()
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        if(horizontal < 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
}
