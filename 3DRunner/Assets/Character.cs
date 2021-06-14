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
            int _newIndex = targetPointIndex;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _newIndex--;
                StartMove();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _newIndex++;
                StartMove();
            }

            targetPointIndex = Mathf.Clamp(_newIndex, 0, pointsTrs.Length - 1);

            if (moveProgress < 1f)
            {
                moveProgress = Mathf.Clamp(moveProgress + moveSpeed * Time.deltaTime, 0f, 1f);
                transform.position = Vector3.Lerp(startMovePos, pointsTrs[targetPointIndex].position, moveProgress);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && characterRigidbody.velocity.y == 0)
                {
                    needJump = true;
                }
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