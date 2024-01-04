using UnityEngine;
using System;

namespace Assets.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        private int _score;

        public event Action<int> ScoreChanged;

        public void Add()
        {
            _score++;
            ScoreChanged?.Invoke(_score);
        }

        public void Reset()
        {
            _score -= _score;
            ScoreChanged?.Invoke(_score);
        }
    }
}