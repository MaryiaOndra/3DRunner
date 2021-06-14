using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Core;
using UnityEngine;

namespace Runner.Base
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField]
        int scoresPerUnit;

        public int InGameScores { get; private set; }
        public int BestScores { get; private set; }

        public void RegisterResult(float _distance) 
        {
            InGameScores = CalculateScores(_distance);

            if (InGameScores > BestScores)
                BestScores = InGameScores;        
        }

       public int CalculateScores(float _distance)
       {
            int _scores = (int)(scoresPerUnit * _distance);
            return _scores;
       }

        public int Score { get; set; }
    }
}
