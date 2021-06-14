using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent onObstacleTriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        onObstacleTriggerEvent.Invoke();
    }
}