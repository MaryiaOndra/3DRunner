using System;
using System.Collections;
using System.Collections.Generic;
using Runner.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class GameDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<GameScreen>().ShowAndStartGame();
        }
        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(GameScreen))
            {
                if (_exitCode == GameScreen.Exit_Settings)
                    SetCurrentScreen<SettingsScreen>().ShowScreen();
                else if (_exitCode == GameScreen.Exit_Result)
                    SetCurrentScreen<ResultScreen>().ShowScreen();
            }
            else if (_screenType == typeof(SettingsScreen))
            {
                if (_exitCode == SettingsScreen.Exit_Back)
                    ToBackScreen();
            }
            else if (_screenType == typeof(ResultScreen))
            {
                if (_exitCode == ResultScreen.Exit_Menu)
                    SceneManager.LoadScene(ScenesIds.Menu);
                else if (_exitCode == ResultScreen.Exit_Replay)
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();
            }
        }
    }
}
