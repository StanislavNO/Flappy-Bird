using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Enemy _enemyPrefab;

        private Queue<Enemy> _pool;

        public IEnumerable<Enemy> PolledObject => _pool;

        private void Awake()
        {
            _pool = new();
        }

        public Enemy GetEnemy()
        {
            if(_pool.Count == 0)
            {
                var prefab = Instantiate(_enemyPrefab);
                prefab.transform.parent = _container;
                
                return prefab;
            }
            
            return _pool.Dequeue();
        }

        public void PutObject(Enemy enemy)
        {
            _pool.Enqueue(enemy);
            enemy.gameObject.SetActive(false);
        }

        public void Reset()
        {
            List<Enemy> enemies = 
                _container
                .GetComponentsInChildren<Enemy>()
                .ToList();

            foreach (Enemy enemy in enemies)
                PutObject(enemy);
        }
    }
}