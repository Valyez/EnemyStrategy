using Movement;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private MovementStrategy _currentStrategy;
    

    private void Update()
    {
        if (_currentStrategy != null)
        {
            _currentStrategy.Move(gameObject);
        }
    }

    public void Initialize(MovementStrategiesEnum newStrategy)
    {
        SwapStrategy(newStrategy);
    }

    public void SwapStrategy(MovementStrategiesEnum newStrategy)
    {
        _currentStrategy = MovementStrategies.GetStrategyByMovementStrategiesEnum(newStrategy);
    }
}