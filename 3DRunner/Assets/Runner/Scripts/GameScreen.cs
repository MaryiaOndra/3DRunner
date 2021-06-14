using System.Collections;
using System.Collections.Generic;
using Runner.Base;
using Runner.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        ScoresPanel scoresPanel;

        [SerializeField]
        TilesMover tilesMover;

        [SerializeField]
        Character character;

        [SerializeField]
        TouchToCharacterAdapter adapter;

        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Result = "Exit_Result";

        public void ShowAndStartGame() 
        {
            ShowScreen();

            adapter.RequestDirectionAction = character.OnRequestMove;
            character.LoseAction = OnPlayerLose;
            character.IsRunning = true;
            tilesMover.IsMove = true;
        }

        void Update()
        {
            scoresPanel.SetScores(GameInfo.Instance.CalculateScores(tilesMover.MoveDistance));
        }

        public void OnSettingsPressed()
        {
            Exit(Exit_Settings);
        }


        public void OnPlayerLose()
        {
            tilesMover.IsMove = false;
            GameInfo.Instance.RegisterResult(tilesMover.MoveDistance);

            Exit(Exit_Result);
        }
    }
}
