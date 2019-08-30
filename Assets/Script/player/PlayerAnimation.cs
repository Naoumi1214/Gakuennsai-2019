using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    bool runnable = true; //走ることが可能ならばtrue
    bool isGround = true; //ジャンプが可能ならばtrue

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGround = false;
        }

        if (runnable && rb2d.velocity.y == 0) //走る
        {
            animator.SetBool("Run", true);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
        }
        else if (!isGround && rb2d.velocity.y > 0) //上昇
        {
            animator.SetBool("Up", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle",false);
        }
        else if (rb2d.velocity.y < 0) //降下
        {
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("stop_left")&&rb2d.velocity.y==0) //止まる
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
        if (collision.CompareTag("stop_left"))
        {
            runnable = true;
        }
    }
}
