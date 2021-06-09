using System.Collections;
using System.Collections.Generic;
using Runner.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Base
{
    public class TemplateDirector : AppDirector
    {
        protected override void Awake()
        {
            base.Awake();

            SceneManager.LoadScene("Menu");
        }
    }
}
