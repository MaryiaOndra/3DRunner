using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    static readonly int FL_SPEED = Animator.StringToHash("MoveSpeed");
    static readonly int BOOL_GROUNDED = Animator.StringToHash("Grounded");

    [SerializeField]
    Transform[] pointsTrs;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    FloorTrigger floorTrigger;

    Animator characterAnimator;
    Rigidbody characterRigidbody;

    int targetPointIndex;
    float moveProgress;
    Vector3 startMovePos;
    bool needJump;
    bool isRunning;

    public bool IsRunning
    {
        get => isRunning;

        set
        {
            isRunning = value;
            characterAnimator.SetFloat(FL_SPEED, isRunning ? 1 : 0);
        }
    }
    public Action LoseAction { get; set; }

    void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
        startMovePos = transform.position;
    }

    private void Update()
    {
        if (IsRunning)
        {
            if (moveProgress < 1f)
            {
                moveProgress = Mathf.Clamp(moveProgress + moveSpeed * Time.deltaTime, 0f, 1f);
                transform.position = Vector3.Lerp(startMovePos, pointsTrs[targetPointIndex].position, moveProgress);
            }
        }

        characterAnimator.SetBool(BOOL_GROUNDED, floorTrigger.IsGrounded);
    }

    private void FixedUpdate()
    {
        if (needJump)
        {
            needJump = false;
            characterRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnRequestMove(CharacterMoveDirection _direction) 
    {
        if (_direction == CharacterMoveDirection.UP)
        {
            if (floorTrigger.IsGrounded)
            {
                needJump = true;
            }
        }
        else
        {
            int _newIndex = targetPointIndex;
            if (_direction == CharacterMoveDirection.LEFT)
            {
                _newIndex--;
            }
            else if (_direction == CharacterMoveDirection.RIGHT)
            {
                _newIndex++;
            }

            targetPointIndex = Mathf.Clamp(_newIndex, 0, pointsTrs.Length - 1);
            
            StartMove();
        }
    }

    void StartMove()
    {
        moveProgress = 0;
        startMovePos = transform.position;
    }

    public void OnObstacleTriggered()
    {
        IsRunning = false;
        LoseAction.Invoke();
    }
}

public enum CharacterMoveDirection 
{
    UP,
    LEFT,
    RIGHT
}