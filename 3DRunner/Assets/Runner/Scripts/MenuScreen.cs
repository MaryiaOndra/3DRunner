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
        TextMeshProUGUI scoreText;

        public override void ShowScreen()
        {
            base.ShowScreen();
            scoreText.text = GameInfo.Instance.Score.ToString();
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
