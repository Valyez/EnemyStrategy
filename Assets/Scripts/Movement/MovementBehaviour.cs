using Characters;
using DefaultNamespace;
using Movement;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private IMovementStrategy _currentStrategy;
    private ControlPointsHolder _controlPointsHolder;
    private Hero _hero;
    

    private void Update()
    {
        if (_currentStrategy != null)
        {
            _currentStrategy.Move(gameObject);
        }
    }

    public void Initialize(MovementStrategiesEnum newStrategy, ControlPointsHolder controlPointsHolder, Hero hero)
    {
        _controlPointsHolder = controlPointsHolder;
        _hero = hero;
        SwapStrategy(newStrategy, hero);
    }

    public void SwapStrategy(MovementStrategiesEnum newStrategy, Hero hero)
    {
        _currentStrategy = MovementStrategies.GetStrategyByMovementStrategiesEnum(newStrategy);
        _currentStrategy.Initialize(_controlPointsHolder, hero);
    }
}