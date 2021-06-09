﻿using System.Collections;
using System.Collections.Generic;
using Runner.Base;
using Runner.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class GameScreen : BaseScreen
    {
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Result = "Exit_Result";

        public void ShowAndStartGame() 
        {
            ShowScreen();
            GameInfo.Instance.Score = 10;
        }

        public void OnSettingsPressed()
        {
            Exit(Exit_Settings);
        }


        public void OnGameEndScreen()
        {
            Exit(Exit_Result);
        }
    }
}