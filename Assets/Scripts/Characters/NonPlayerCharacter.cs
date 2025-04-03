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

        private void Awake()
        {
            _movementBehaviour = gameObject.GetComponent<MovementBehaviour>();
            _movementBehaviour.Initialize(_defaultStrategy);
        }

        public void Initialize(MovementStrategiesEnum defaultStrategy, MovementStrategiesEnum triggeredStrategy)
        {
            _defaultStrategy = defaultStrategy;
            _triggeredStrategy = triggeredStrategy;
            _movementBehaviour.Initialize(_defaultStrategy);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                _movementBehaviour.SwapStrategy(_triggeredStrategy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Hero hero = other.GetComponent<Hero>();

            if (hero != null)
            {
                _movementBehaviour.SwapStrategy(_defaultStrategy);
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
            ParticleSystem particleSystem = Instantiate(_particleSystemPrefab, gameObject.transform.position, Quaternion.identity);
            particleSystem.Play();
        }
    }
}