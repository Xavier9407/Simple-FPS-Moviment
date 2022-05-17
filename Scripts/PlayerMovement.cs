using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    [Header("Speed Config")]
    [SerializeField] float forwardSpeed = 5f;
    [SerializeField] float strafeSpeed = 5f;

    float gravity;
    float jumpSpeed;
    [Header("Jump Config")]
    [SerializeField] float MaxJumpHeight = 1.5f;
    [SerializeField] float timeToMaxHeight = 0.3f;

    void Start()
    {
        gravity = (-2 * MaxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * MaxJumpHeight) / timeToMaxHeight;
        controller = GetComponent<CharacterController>();
       
    }

    
    void Update()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }
  
        Vector3 finalVelocity = forward + strafe + vertical;
  
        controller.Move(finalVelocity * Time.deltaTime);
    }

}
