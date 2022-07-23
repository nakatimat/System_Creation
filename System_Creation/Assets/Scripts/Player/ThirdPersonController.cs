using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private CharacterController controller;
    private PlayerAnimationController _playerAnim;
        
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [SerializeField]
    private float _speed = 1f;
    private float _maxSpeed = 5f;
    private float _minSpeed = 1f;
    private float _acceleration = 4f;
    private float _desaceleration = 4f;

    //controle de gravidade
    private float gravity = -4.5f;
    private Vector3 velocityY;
    //---------------------

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _playerAnim = GetComponent<PlayerAnimationController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;        
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        HandleMovementsAndRotation(horizontal, vertical);
        HandleGravity();
    }

    void HandleMovementsAndRotation(float horizontal, float vertical) 
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            WalkOrRunningSpeed();

            controller.Move(moveDir.normalized * _speed * Time.deltaTime);
        }
    }

    void WalkOrRunningSpeed()
    {
        if (_playerAnim.IsRunning && _speed < _maxSpeed) 
        {
            _speed += _acceleration * Time.deltaTime;
        }

        if (!_playerAnim.IsRunning && _speed > _minSpeed) 
        {
            if (_speed < _minSpeed)
            {
                _speed = _minSpeed;
            }
            else {
                _speed -= _desaceleration * Time.deltaTime;
            }
        }

    }


    void HandleGravity() 
    {
        if (!controller.isGrounded)
        {
            velocityY.y += gravity * Time.deltaTime;
            controller.Move(velocityY);
        }
    }


}
