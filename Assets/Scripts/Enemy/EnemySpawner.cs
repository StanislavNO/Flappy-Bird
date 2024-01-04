using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _lowerBound;
        [SerializeField] private float _upperBound;
        [SerializeField] private ObjectPool _pool;

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        public void Reset()
        {
            _pool.Reset();
        }

        private IEnumerator SpawnEnemy()
        {
            var wait = new WaitForSeconds(_delay);

            while (enabled)
            {
                Spawn();
                yield return wait;
            }
        }

        private void Spawn()
        {
            float spawnPositionY = Random.Range(
                _lowerBound,
                _upperBound);

            Vector3 spawnPoint = new(
                transform.position.x,
                spawnPositionY,
                transform.position.z);

            var enemy = _pool.GetEnemy();
            enemy.transform.position = spawnPoint;
            enemy.gameObject.SetActive(true);
        }
    }
}