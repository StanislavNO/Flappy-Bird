using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectRemover : MonoBehaviour
    {
        [SerializeField] protected ObjectPool Pool;
        [SerializeField] protected ScoreCounter ScoreCounter;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                Pool.PutObject(enemy);
                ScoreCounter.Add();
            }
            else
                collision.gameObject.SetActive(false);
        }
    }
}