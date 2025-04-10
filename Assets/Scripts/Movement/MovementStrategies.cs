using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

namespace Movement
{
    /**
      * Класс - Enum в котором будут собраны все возможные стратегии передвижения.
      * Доступ к ним получаем через статический метод GetStrategyByMovementStrategiesEnum.
      */
    public static class MovementStrategies
    {
        private static readonly Dictionary<MovementStrategiesEnum, Type> _movementStrategiesDictionary;

        static MovementStrategies()
        {
            _movementStrategiesDictionary = new Dictionary<MovementStrategiesEnum, Type>
            {
                {MovementStrategiesEnum.IDLE, typeof(IdleStrategy)},
                {MovementStrategiesEnum.PATROLLING, typeof(PatrollingStrategy)},
                {MovementStrategiesEnum.RANDOM_WALK, typeof(RandomWalkStrategy)},
                {MovementStrategiesEnum.RUN_AWAY, typeof(RunAwayStrategy)},
                {MovementStrategiesEnum.CHASE, typeof(ChaseStrategy)},
                {MovementStrategiesEnum.AFRAID_AND_DIE, typeof(AfraidAndDieStrategy)},
                {MovementStrategiesEnum.WASD, typeof(WASDStrategy)}
            };

        }

        public static IMovementStrategy GetStrategyByMovementStrategiesEnum(MovementStrategiesEnum strategiesEnum)
        {
            return Activator.CreateInstance(_movementStrategiesDictionary.GetValueOrDefault(strategiesEnum)) as IMovementStrategy;
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