using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMover : MonoBehaviour
{

    [SerializeField]
    List<Tile> tiles;

    [SerializeField]
    float speed;

    public bool IsMove { get; set;  }
    public float MoveDistance { get; private set; }

    void Update()
    {
        if (IsMove)
        {
            float _deltaPos = -speed * Time.deltaTime;
            MoveDistance += Mathf.Abs(_deltaPos);

            for (int i = 0; i < tiles.Count; i++)
            {
                var _tile = tiles[i];

                _tile.Position -= speed * Time.deltaTime;

                if (_tile.Position < - _tile.Lenght)
                {
                    var _lastTile = tiles[tiles.Count - 1];
                    _tile.Position = _lastTile.Position + _lastTile.Lenght;
                    tiles.RemoveAt(i);
                    tiles.Add(_tile);
                    i--;
                }
            }
        }
    }
}
