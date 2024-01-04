using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private float _tapForce;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxRotationZ;
        [SerializeField] private float _minRotationZ;

        private Vector3 _startPosition;
        private Rigidbody2D _rigidBody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;

        private void Awake()
        {
            _startPosition = transform.position;
            _rigidBody2D = GetComponent<Rigidbody2D>();

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidBody2D.velocity = new(_speed, _tapForce);
                transform.rotation = _maxRotation;
            }

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                _minRotation,
                _rotationSpeed * Time.deltaTime);
        }

        public void Reset()
        {
            _rigidBody2D.velocity = Vector2.zero;
            _rigidBody2D.angularVelocity = 0;
            transform.position = _startPosition;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}