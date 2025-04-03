using Movement;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private MovementStrategy _currentStrategy;
    

    private void Update()
    {
        _currentStrategy.Move(gameObject);
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