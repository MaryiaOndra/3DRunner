using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    void OnTriggerStay(Collider other)
    {
        IsGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }
}
