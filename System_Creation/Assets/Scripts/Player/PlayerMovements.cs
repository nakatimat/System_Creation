using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerAnimationController _playerAnim;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    private float forwardSpeed_ = 3f;
    private float strafeSpeed_ = 3f;
    //controle de gravidade
    private float gravity = -4.5f;
    private Vector3 velocityY;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_playerAnim = GetComponent<PlayerAnimationController>();
    }

    
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        HandlePlaceMovements(horizontal, vertical);
        HandleGravity();
    }

    private void HandlePlaceMovements(float horizontal, float vertical) 
    {
        forward = vertical * forwardSpeed_ * transform.forward;
        strafe = horizontal * strafeSpeed_ * transform.right;

        Vector3 finalVelocity = forward + strafe;

        _controller.Move(finalVelocity * Time.deltaTime);
    }

    private void HandleGravity() 
    {
        if (!_controller.isGrounded) 
        {
            velocityY.y += gravity * Time.deltaTime;
            _controller.Move(velocityY);
        }
    }
}
