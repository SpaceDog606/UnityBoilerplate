using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector3.up/70;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector3.down/70;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector3.right/70;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector3.left/70;
        }
    }
}
