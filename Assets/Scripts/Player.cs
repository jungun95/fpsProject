using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10;

    Rigidbody rigidbody;
    Vector3 movement;
    float horizontal, vertical;
   
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        movement.Set(horizontal, 0f, vertical);
        movement = movement.normalized * playerSpeed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }
}
