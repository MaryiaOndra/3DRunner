using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    Transform[] pointsTrs;

    [SerializeField]
    float moveSpeed;

    Animator characterAnimator;
    Rigidbody characterRigidbody;

    int targetPointIndex;
    float moveProgress;
    Vector3 startMovePos;

    public bool IsMove { get; set; }
    public Action LoseAction { get; set; }

    void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        characterRigidbody = GetComponent<Rigidbody>();
        startMovePos = transform.position;
    }

    private void Update()
    {
        if (IsMove)
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
        }
    }

    void StartMove()
    {
        moveProgress = 0;
        startMovePos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsMove = false;
        LoseAction.Invoke();
    }
}