using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    private int _VelocityZ;
    private float _maxWalkSpeed = 0.4f;
    private float acceleration = 2f;
    private float desaceleration = 2f;

    private float _animationSpeed = 0f;

    public bool IsWalking { get; private set; }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _VelocityZ = Animator.StringToHash("Velocity");
    }

    
    void Update()
    {
        IsWalking = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

        HandleMovements(IsWalking);
    }

    void HandleMovements(bool IsWalking) 
    {
        if (IsWalking && _animationSpeed < _maxWalkSpeed) 
        {
            _animationSpeed += Time.deltaTime * acceleration;
        }

        if (!IsWalking && _animationSpeed > 0f) 
        {
            _animationSpeed -= Time.deltaTime * desaceleration;
        }

        _animator.SetFloat(_VelocityZ, _animationSpeed);
    }
}
