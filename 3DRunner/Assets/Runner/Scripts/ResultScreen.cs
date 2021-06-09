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
        public const string Exit_Menu = "Exit_Menu";
        public const string Exit_Replay = "Exit_Replay";

        [SerializeField]
        TextMeshProUGUI scoreText;

        public override void ShowScreen()
        {
            base.ShowScreen();
            scoreText.text = GameInfo.Instance.Score.ToString();
        }

        public void OnRestartPressed() 
        {
            Exit(Exit_Replay);    
        }

        public void OnMenuPressed() 
        {
            Exit(Exit_Menu);
        }
    }
}
