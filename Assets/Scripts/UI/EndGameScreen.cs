﻿using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class EndGameScreen : Window
    {
        public event Action RestartButtonClicked;

        protected override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}