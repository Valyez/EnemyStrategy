using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Movement
{
    /**
      * Класс - Enum в котором в виде статический полей будут собраны все возможные стратегии передвижения.
      * Доступ к ним получаем через статический метод GetStrategyByMovementStrategiesEnum.
      */
    public class MovementStrategies
    {
        private static readonly MovementStrategies WASD = new MovementStrategies(
            MovementStrategiesEnum.WASD,
            new WASDStrategy());
        
        private static readonly MovementStrategies RUN_AWAY = new MovementStrategies(
            MovementStrategiesEnum.WASD,
            new RunAwayStrategy());

   

        private static readonly Dictionary<MovementStrategiesEnum, MovementStrategy> _movementStrategiesDictionary;

        private readonly MovementStrategiesEnum _name;

        private MovementStrategy Strategy { get; }

        static MovementStrategies()
        {
            _movementStrategiesDictionary = new Dictionary<MovementStrategiesEnum, MovementStrategy>();

            foreach (FieldInfo field in typeof(MovementStrategies).GetFields(BindingFlags.NonPublic | BindingFlags.Static))
            {
                object value = field.GetValue(null);

                if (value is MovementStrategies strategy)
                {
                    _movementStrategiesDictionary.Add(strategy._name, strategy.Strategy);
                }
            }
        }

        private MovementStrategies(MovementStrategiesEnum name, MovementStrategy strategy)
        {
            _name = name;
            Strategy = strategy;
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