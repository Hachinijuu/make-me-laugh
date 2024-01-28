using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate((Vector2.up * movespeed)* Time.deltaTime);
            animator.SetInteger("moveState", 2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down * movespeed) * Time.deltaTime);
            animator.SetInteger("moveState", 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left * movespeed) * Time.deltaTime);
            animator.SetInteger("moveState", 3);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right * movespeed) * Time.deltaTime);
            animator.SetInteger("moveState", 4);
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) 
        {
            animator.SetInteger("moveState", 0);
        }
    }
}
