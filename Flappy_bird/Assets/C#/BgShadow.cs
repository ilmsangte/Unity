using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShadow : MonoBehaviour
{
    public GameObject panel;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        } 
    }
    public void Shadow(){
        Animator animator = panel.GetComponent<Animator>();
        bool isOpen = animator.GetBool("isOpen");

        animator.SetBool("isOpen",!isOpen);
    }
}
