using System.Collections;
using System.Collections.Generic;
using Runner.Core;
using UnityEngine;

namespace Runner
{
    public class SettingsScreen : BaseScreen
    {
        public const string Exit_Back = "Exit_Back";

        public void OnBackPressed() 
        {
            Exit(Exit_Back);
        }
    }
}
