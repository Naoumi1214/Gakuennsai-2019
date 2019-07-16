using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Run", false);
        }
        else if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);
        }else if (rb2d.velocity.y==0)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Down", false);
        }
    }
}
