using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToCharacterAdapter : MonoBehaviour
{
    const int MIN_ANGLE = 45; 

    public Action<CharacterMoveDirection> RequestDirectionAction { get; set; }

    public void OnSwiped(float _angle)
    {
        Debug.Log(name + "OnSwiped: " + _angle);

        CharacterMoveDirection _direction;

        if (Mathf.Abs(_angle) < MIN_ANGLE)
        {
            _direction = CharacterMoveDirection.UP;
        }
        else
        {
            _direction = _angle < 0 ? CharacterMoveDirection.LEFT : CharacterMoveDirection.RIGHT;
        }

        RequestDirectionAction.Invoke(_direction);    
    }
}
