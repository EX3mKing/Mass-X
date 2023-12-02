using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public Transform orientation;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = Input.GetAxisRaw("Horizontal") * speed * orientation.right +
                      Input.GetAxisRaw("Vertical") * speed * orientation.forward +
                      rb.velocity.y * Vector3.up;

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.Interact();
        }
    }

    private void FixedUpdate()
    {
        GameManager.Instance.GetInteractable();
    }
}
