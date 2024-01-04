using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class NewBehaviourScript1 : MonoBehaviour
    {
        public Transform a;
        public Transform b;

        // Use this for initialization
        void Update()
        {
            Debug.Log(Vector3.Angle(a.position,b.position));
            transform.LookAt(b, new(0,0,1));
        }

    }
}