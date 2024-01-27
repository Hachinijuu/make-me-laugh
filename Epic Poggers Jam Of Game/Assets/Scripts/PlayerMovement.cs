using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int movespeed;

    // Start is called before the first frame update
    void Start()
    {
        movespeed = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            transform.Translate((Vector2.up * movespeed)* Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector2.down * movespeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector2.left * movespeed) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector2.right * movespeed) * Time.deltaTime);
        }
    }
}
