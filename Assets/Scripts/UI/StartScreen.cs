using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class StartScreen : Window
    {
        public event Action PlayButtonClicked;

        protected override void OnButtonClick()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}