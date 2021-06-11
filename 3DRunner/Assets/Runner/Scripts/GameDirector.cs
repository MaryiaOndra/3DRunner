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

            SetCurrentScreen<MenuScreen>().ShowScreen();
        }
        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(MenuScreen))
            {
                if (_exitCode == MenuScreen.Exit_Game)
                {
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();                
                }
            }
            else if(_screenType == typeof(GameScreen))
            {
                if (_exitCode == GameScreen.Exit_Result)
                {
                    SetCurrentScreen<ResultScreen>().ShowScreen();
                }
            }
            else if (_screenType == typeof(ResultScreen))
            {
                if (_exitCode == ResultScreen.Exit_Replay)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
            }
        }
    }
}
