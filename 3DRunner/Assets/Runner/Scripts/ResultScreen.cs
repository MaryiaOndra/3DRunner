using System.Collections;
using System.Collections.Generic;
using Runner.Base;
using Runner.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class ResultScreen : BaseScreen
    {
        public const string Exit_Replay = "Exit_Replay";

        [SerializeField]
        TMP_Text scoreText;

        public override void ShowScreen()
        {
            base.ShowScreen();
            scoreText.text = GameInfo.Instance.InGameScores.ToString();
        }

        public void OnRestartPressed() 
        {
            Exit(Exit_Replay);    
        }
    }
}
