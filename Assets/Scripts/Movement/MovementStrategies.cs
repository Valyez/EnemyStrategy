using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Movement
{
    /**
      * Класс - Enum в котором будут собраны все возможные стратегии передвижения.
      * Доступ к ним получаем через статический метод GetStrategyByMovementStrategiesEnum.
      */
    public static class MovementStrategies
    {
        private static readonly Dictionary<MovementStrategiesEnum, MovementStrategy> _movementStrategiesDictionary;

        static MovementStrategies()
        {
            _movementStrategiesDictionary = new Dictionary<MovementStrategiesEnum, MovementStrategy>
            {
                {MovementStrategiesEnum.IDLE, new IdleStrategy()},
                {MovementStrategiesEnum.PATROLLING, new PatrollingStrategy()},
                {MovementStrategiesEnum.RANDOM_WALK, new RandomWalkStrategy()},
                {MovementStrategiesEnum.RUN_AWAY, new RunAwayStrategy()},
                {MovementStrategiesEnum.CHASE, new ChaseStrategy()},
                {MovementStrategiesEnum.AFRAID_AND_DIE, new AfraidAndDieStrategy()},
                {MovementStrategiesEnum.WASD, new WASDStrategy()}
            };

        }

        public static MovementStrategy GetStrategyByMovementStrategiesEnum(MovementStrategiesEnum strategiesEnum)
        {
            return _movementStrategiesDictionary.GetValueOrDefault(strategiesEnum);
        }
    }

    public enum MovementStrategiesEnum
    {
        IDLE,
        PATROLLING,
        RANDOM_WALK,
        RUN_AWAY,
        CHASE,
        AFRAID_AND_DIE,
        WASD
    }
}