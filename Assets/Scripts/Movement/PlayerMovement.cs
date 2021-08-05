using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    KeyboardMouseInput keyboardMouseInput;

    public float speed = 10f;
    public float jumpHeight = 5f;
    bool isGrounded;

    //physics settings
    public float gravity = -9.81f;
    Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        keyboardMouseInput = FindObjectOfType<KeyboardMouseInput>();
    }

    private void OnEnable()
    {
        keyboardMouseInput.OnKeyboardInputSpace += Jump;
    }

    private void OnDisable()
    {
        keyboardMouseInput.OnKeyboardInputSpace -= Jump;
    }

    void Update()
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

    void Jump()
    {
        /*
        //Jump
        if (Physics.Raycast(controller.transform.position, Vector3.down, float controller.))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        */
    }

}
