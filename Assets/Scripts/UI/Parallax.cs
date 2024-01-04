using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private RawImage _image;
        [SerializeField] private float _speed;
        [SerializeField] private bool _isVertical;
        [SerializeField] private bool _isHorizontal;

        private float _fadeTime;

        private void Update()
        {
            _fadeTime += _speed * Time.deltaTime;

            TryMove();
        }

        private void TryMove()
        {
            if (_isVertical)
            {
                _image.uvRect = new(
                    _image.uvRect.x,
                    _fadeTime,
                    _image.uvRect.width,
                    _image.uvRect.height);
            }

            if (_isHorizontal)
            {
                _image.uvRect = new(
                    _fadeTime,
                    _image.uvRect.y,
                    _image.uvRect.width,
                    _image.uvRect.height);
            }
        }
    }
}