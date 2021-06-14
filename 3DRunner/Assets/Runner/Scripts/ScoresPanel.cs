using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresPanel : MonoBehaviour
{
    [SerializeField]
    TMP_Text scores;

    public void SetScores(int _scores)
    {
        scores.text = _scores.ToString();    
    }
}
