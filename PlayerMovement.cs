using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform PlayerMesh;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float runningSpeed = 13.0f;
    public float crouchSpeed = 5.0f;
    public float walkSpeed = 8.0f;
    private float charHeight = 3.6f;
    private bool Standing = true;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Standing)
        {
            speed = runningSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && Standing)
        {
            speed = walkSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            controller.height -= 1.4f;
            PlayerMesh.position = new Vector3(PlayerMesh.position.x, PlayerMesh.position.y - 0.7f, PlayerMesh.position.z);
            speed = crouchSpeed;
            Standing = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = charHeight;
            PlayerMesh.position = new Vector3(PlayerMesh.position.x, PlayerMesh.position.y + 0.7f, PlayerMesh.position.z);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runningSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = walkSpeed;
            }
            speed = walkSpeed;
            Standing = true;
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
