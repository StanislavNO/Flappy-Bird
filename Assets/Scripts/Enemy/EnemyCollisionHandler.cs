using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyCollisionHandler : ObjectRemover
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out IAttacker _))
            {
                Pool.PutObject(gameObject.GetComponent<Enemy>());
                ScoreCounter.Add();
            }
        }
    }
}