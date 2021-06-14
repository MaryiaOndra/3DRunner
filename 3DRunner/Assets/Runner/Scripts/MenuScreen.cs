using System.Collections;
using System.Collections.Generic;
using Runner.Base;
using Runner.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class MenuScreen : BaseScreen
    {
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Game = "Exit_Game";

        [SerializeField]
        ScoresPanel scoreText;

        public override void ShowScreen()
        {
            base.ShowScreen();
            scoreText.SetScores(GameInfo.Instance.BestScores);
        }

        public void OnSettingsPressed() 
        {
            Exit(Exit_Settings);
        }

        public void OnGamePressed()
        {
            Exit(Exit_Game);
        }
    }
}
