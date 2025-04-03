using Movement;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MovementBehaviour))]
public class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private MovementStrategiesEnum _defaultStrategy;
    [SerializeField] private MovementStrategiesEnum _triggeredStrategy;

    private MovementBehaviour _movementBehaviour;

    private void Awake()
    {
        _movementBehaviour = gameObject.GetComponent<MovementBehaviour>();
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
}