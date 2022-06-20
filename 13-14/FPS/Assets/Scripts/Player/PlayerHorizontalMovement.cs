using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundedCheck), typeof(PlayerCrouching), typeof(Rigidbody))]
public class PlayerHorizontalMovement : MonoBehaviour
{
    [Header("SPEED")]
    [SerializeField, Min(0)] private float _walkSpeed;
    [SerializeField, Min(0)] private float _runSpeed;
    [SerializeField, Min(0)] private float _speedInAir;
    [SerializeField, Min(0)] private float _crouchSpeed;
    
    private GroundedCheck _groundedCheck;
    private Rigidbody _rigidbody;
    private PlayerCrouching _playerCrouching;

    private Vector3 _impulse;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerCrouching = GetComponent<PlayerCrouching>();
        _groundedCheck = GetComponent<GroundedCheck>();
    }

    void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _impulse = new Vector3(inputVector.x, 0.0f, inputVector.y).normalized;

        if (_groundedCheck.IsGrounded)
        {
            if (_playerCrouching.IsCrouched)
                _impulse *= _crouchSpeed;
            else
                _impulse *= Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
        }
        else
            _impulse *= _speedInAir;
    }

    void FixedUpdate() => _rigidbody.AddRelativeForce(_impulse, ForceMode.Impulse);

#if UNITY_EDITOR

    private void OnValidate()
    {
        if (_walkSpeed > _runSpeed)
            _walkSpeed = _runSpeed;

        if (_crouchSpeed > _walkSpeed)
            _crouchSpeed = _walkSpeed;
    }

#endif
}
