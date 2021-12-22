using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject pannel;
    public void panel_Open(){
        Animator animator = pannel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("isOpen");

        animator.SetBool("isOpen",!isOpen);
    }
}
