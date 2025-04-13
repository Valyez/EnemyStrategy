using System;
using DefaultNamespace;
using Movement;
using Movement.MovementBehaviour;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Collider))]
    public class NonPlayerCharacter : Character, ICanDie
    {
        [SerializeField] private MovementStrategiesEnum _defaultStrategy;
        [SerializeField] private MovementStrategiesEnum _triggeredStrategy;
        [SerializeField] private ParticleSystem _particleSystemPrefab;
        
        public void Initialize(MovementStrategiesEnum defaultStrategy,
            MovementStrategiesEnum triggeredStrategy,
            ControlPointsHolder controlPointsHolder,
            Hero hero)
        {
            _defaultStrategy = defaultStrategy;
            _triggeredStrategy = triggeredStrategy;
            movementBehaviour = new NonPlayerCharacterMovementBehaviour(controlPointsHolder, hero);
            movementBehaviour.SwapStrategy(_defaultStrategy);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                movementBehaviour.SwapStrategy(_triggeredStrategy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                movementBehaviour.SwapStrategy(_defaultStrategy);
            }
        }
        
        public void Die()
        {
            gameObject.SetActive(false);
            ParticleSystem particleSystem = Instantiate(_particleSystemPrefab, transform.position, Quaternion.identity);
            particleSystem.Play();
        }
    }
}