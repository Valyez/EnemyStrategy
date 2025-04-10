using DefaultNamespace;
using Movement;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(MovementBehaviour))]
    public class NonPlayerCharacter : MonoBehaviour, ICanDie
    {
        [SerializeField] private MovementStrategiesEnum _defaultStrategy;
        [SerializeField] private MovementStrategiesEnum _triggeredStrategy;
        [SerializeField] private ParticleSystem _particleSystemPrefab;

        private MovementBehaviour _movementBehaviour;
        private Hero _hero;

        public void Initialize(MovementStrategiesEnum defaultStrategy,
            MovementStrategiesEnum triggeredStrategy,
            ControlPointsHolder controlPointsHolder,
            Hero hero)
        {
            _defaultStrategy = defaultStrategy;
            _triggeredStrategy = triggeredStrategy;
            _hero = hero;
            _movementBehaviour = gameObject.GetComponent<MovementBehaviour>();
            _movementBehaviour.Initialize(_defaultStrategy, controlPointsHolder, hero);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                _movementBehaviour.SwapStrategy(_triggeredStrategy,_hero);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                _movementBehaviour.SwapStrategy(_defaultStrategy,_hero);
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