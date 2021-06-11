using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    float lenght;

    public float Lenght => lenght;

    public float Position 
    {
        get => transform.localPosition.z;
        set 
        {
            var _pos = transform.localPosition;
            _pos.z = value;
            transform.localPosition = _pos;
        }
    }
}
