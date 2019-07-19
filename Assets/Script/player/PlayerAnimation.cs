using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    bool runnable = true; //走ることが可能ならばtrue
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (runnable)
        {
            if(rb2d.velocity.y == 0)
            {
                animator.SetBool("Run", true);
                animator.SetBool("Down", false);
            }
        }

        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle",false);
        }
        else if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("stop"))
        {
            runnable = false;

            animator.SetBool("Idle", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Run", false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        runnable = true;
    }
}
