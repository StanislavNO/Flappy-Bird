using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TMP_Text _score;

        private void OnEnable()
        {
            _scoreCounter.ScoreChanged += OnScoreChange;
        }

        private void OnDisable()
        {
            _scoreCounter.ScoreChanged -= OnScoreChange;
        }

        private void OnScoreChange(int score)
        {
            _score.text = score.ToString();
        }
    }
}