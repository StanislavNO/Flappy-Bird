using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private bool _byClick;

        private float _speed = 1f;
        private int _maxBullet = 5;
        private int _bulletCounter;
        private List<Bullet> _bullets;

        private void Awake()
        {
            _bullets = new List<Bullet>();
            CreateBullets();

            foreach (Bullet bullet in _bullets)
            {
                bullet.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            if (_byClick == false)
                StartCoroutine(AttackAndDelay());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            Reset();
        }

        private void Update()
        {
            if (_byClick)
            {
                if (Input.GetKeyDown(KeyCode.A))
                    Shoot();
            }
        }

        private void Shoot()
        {
            Bullet bullet = _bullets[_bulletCounter];
            _bulletCounter++;

            bullet.transform.position = _attackPoint.position;
            bullet.transform.rotation = _attackPoint.rotation;
            bullet.gameObject.SetActive(true);

            if (_bulletCounter == _maxBullet)
                _bulletCounter -= _bulletCounter;
        }

        private IEnumerator AttackAndDelay()
        {
            WaitForSecondsRealtime delay = new(_speed);

            while (gameObject.activeSelf)
            {
                yield return delay;
                Shoot();
            }
        }

        private void CreateBullets()
        {
            for (int i = 0; i < _maxBullet; i++)
            {
                Bullet bullet = Instantiate(_prefab);

                bullet.gameObject.SetActive(false);
                _bullets.Add(bullet);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (_bullets[i] != null)
                    _bullets[i].gameObject.SetActive(false);
            }
        }
    }
}