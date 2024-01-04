using UnityEngine;
using System;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyCollisionHandler : MonoBehaviour
    {
        public event Action<Enemy> DamageDetected;

        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IAttacker _))
                DamageDetected?.Invoke(_enemy);
        }
    }
}