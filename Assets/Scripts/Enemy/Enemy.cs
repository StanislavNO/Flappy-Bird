using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour, IInteractable
    {
        [SerializeField] private int _reward;

        public int Reward => _reward;
    }
}