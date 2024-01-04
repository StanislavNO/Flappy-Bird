using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] protected float Speed;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(
                -(Vector3.up
                * Speed
                * Time.deltaTime)
                , Space.Self);
        }
    }
}