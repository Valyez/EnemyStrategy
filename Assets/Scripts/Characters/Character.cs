using Movement.MovementBehaviour;
using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour
    {
        protected MovementBehaviour movementBehaviour;
        private void Update()
        {
            movementBehaviour.Move(gameObject);
        }
    }
}