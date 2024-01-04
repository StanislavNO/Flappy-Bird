using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Bird _bird;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndGameScreen _endScreen;

        private void OnEnable()
        {
            _bird.GameOver += EndGame;
            _startScreen.PlayButtonClicked += OnPlayButtonClick;
            _endScreen.RestartButtonClicked += OnRestartButtonClick;

            _bird.gameObject.SetActive(false);
            _enemySpawner.gameObject.SetActive(false);
            _endScreen.gameObject.SetActive(false);
            _startScreen.Open();
        }

        private void OnDisable()
        {
            _bird.GameOver -= EndGame;
            _startScreen.PlayButtonClicked -= OnPlayButtonClick;
            _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        }

        private void StartGame()
        {
            Time.timeScale = 1.0f;
            _bird.gameObject.SetActive(false);
            _bird.gameObject.SetActive(true);
            _bird.Reset();
        }

        private void EndGame()
        {
            Time.timeScale = 0f;
            _endScreen.Open();
            _enemySpawner.Reset();
        }

        private void OnRestartButtonClick()
        {
            _endScreen.Close();
            StartGame();
        }

        private void OnPlayButtonClick()
        {
            _startScreen.Close();
            _enemySpawner.gameObject.SetActive(true);
            StartGame();
        }
    }
}