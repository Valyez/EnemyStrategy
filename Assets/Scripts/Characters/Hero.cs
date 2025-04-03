using Movement;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(MovementBehaviour))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private MovementStrategiesEnum _movementStrategy;

        private void Awake()
        {
            MovementBehaviour movementBehaviour = gameObject.GetComponent<MovementBehaviour>();
            movementBehaviour.Initialize(_movementStrategy);
        }
    }
}