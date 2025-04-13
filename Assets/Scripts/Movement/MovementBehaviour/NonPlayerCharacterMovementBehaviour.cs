using System;
using System.Collections.Generic;
using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement.MovementBehaviour
{
    public class NonPlayerCharacterMovementBehaviour : MovementBehaviour
    {
        private readonly ControlPointsHolder _controlPointsHolder;
        private readonly Hero _hero;

        private Dictionary<Type, IMovementStrategy> _movementStrategiesСache;


        public NonPlayerCharacterMovementBehaviour(
            ControlPointsHolder controlPointsHolder,
            Hero hero)
        {
            _controlPointsHolder = controlPointsHolder;
            _hero = hero;
            _currentStrategy = new IdleStrategy();
            _movementStrategiesСache = new Dictionary<Type, IMovementStrategy>();
        }

        public override void SwapStrategy(MovementStrategiesEnum newStrategy)
        {
            Type strategyClazz = MovementStrategiesUtils.GetStrategyByMovementStrategiesEnum(newStrategy);

            if (strategyClazz == null)
            {
                return;
            }

            if (_movementStrategiesСache.ContainsKey(strategyClazz))
            {
                _currentStrategy = _movementStrategiesСache[strategyClazz];
            }
            else
            {
                _currentStrategy = strategyClazz.Name switch
                {
                    nameof(ChaseStrategy) => new ChaseStrategy(_hero),
                    nameof(RunAwayStrategy) => new RunAwayStrategy(_hero),
                    nameof(IdleStrategy) => new IdleStrategy(),
                    nameof(PatrollingStrategy) => new PatrollingStrategy(_controlPointsHolder),
                    nameof(RandomWalkStrategy) => new RandomWalkStrategy(),
                    nameof(AfraidAndDieStrategy) => new AfraidAndDieStrategy(),
                    nameof(WASDStrategy) => new WASDStrategy(),
                    _ => throw new Exception(Constant.UNKNOWN_CLASS_EXCEPTION)
                };

                _movementStrategiesСache.Add(strategyClazz, _currentStrategy);
            }
        }
    }
}