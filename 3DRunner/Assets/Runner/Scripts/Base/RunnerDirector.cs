using System.Collections;
using System.Collections.Generic;
using Runner.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Base
{
    public class RunnerDirector : AppDirector
    {
        protected override void Awake()
        {
            base.Awake();

            SceneManager.LoadScene("Game");
        }
    }
}
