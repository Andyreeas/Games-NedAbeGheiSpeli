using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class NetworkPlayerMovement : NetworkBehaviour
{
    CharacterController controller;
    KeyboardMouseInput keyboardMouseInput;

    public float speed = 10f;
    public float jumpHeight = 5f;
    bool isGrounded;

    //physics settings
    public float gravity = -9.81f;
    Vector3 velocity;

    private void Awake()
    {
        keyboardMouseInput = GetComponentInChildren<KeyboardMouseInput>();
    }

    private void OnEnable()
    {
        keyboardMouseInput.OnKeyboardInputSpace += Jump;

    }

    private void OnDisable()
    {

        keyboardMouseInput.OnKeyboardInputSpace -= Jump;

    }

    private void Start()
    {
        if (IsLocalPlayer)
        {
            controller = GetComponent<CharacterController>();
        }
        else
        {
            // Deactiviert die Camera wenn nicht eigener Player
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
            //physics (gravity)
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2;
            }
        }
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            velocity.y = jumpHeight;
        }
    }
}
