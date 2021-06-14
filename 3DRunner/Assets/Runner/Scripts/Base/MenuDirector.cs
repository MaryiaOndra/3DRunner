using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runner.Core;
using System;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class MenuDirector : SceneDirector
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
                    SceneManager.LoadScene(ScenesIds.Game);
                else if (_exitCode == MenuScreen.Exit_Settings)
                    SetCurrentScreen<SettingsScreen>().ShowScreen();
            }
            else if (_screenType == typeof(SettingsScreen)) 
            {
                if (_exitCode == SettingsScreen.Exit_Back)
                    ToBackScreen();
            }
        }
    }
}
