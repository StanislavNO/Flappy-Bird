using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BirdMover))]
    [RequireComponent(typeof(ScoreCounter))]
    [RequireComponent(typeof(BirdCollisionHandler))]
    public class Bird : MonoBehaviour
    {
        [SerializeField] private BirdCollisionHandler _handler;

        private BirdMover _birdMover;
        private ScoreCounter _scoreCounter;

        public event Action GameOver;

        private void Awake()
        {
            _birdMover = GetComponent<BirdMover>();
            _scoreCounter = GetComponent<ScoreCounter>();
        }

        private void OnEnable()
        {
            _handler.CollisionDetected += ProcessCollision;
        }

        private void OnDisable()
        {
            _handler.CollisionDetected -= ProcessCollision;
        }

        private void OnDestroy()
        {
            Debug.Log("Bird");
        }

        private void ProcessCollision(IInteractable interactable)
        {
            if (interactable is ScoreZone)
            {
                _scoreCounter.Add();
            }
            else if (interactable is Bullet)
            {
                _birdMover.enabled = false;
            }
            else
                GameOver?.Invoke();
        }

        public void Reset()
        {
            gameObject.SetActive(true);
            _birdMover.enabled = true;
            _scoreCounter.Reset();
            _birdMover.Reset();
        }
    }
}