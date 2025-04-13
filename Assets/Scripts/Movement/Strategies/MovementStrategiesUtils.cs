using System;
using System.Collections.Generic;

namespace Movement
{
    /**
      * Класс - Enum в котором будут собраны все возможные стратегии передвижения.
      * Доступ к ним получаем через статический метод GetStrategyByMovementStrategiesEnum.
      */
    public static class MovementStrategiesUtils
    {
        private static readonly Dictionary<MovementStrategiesEnum, Type> _movementStrategiesDictionary;

        static MovementStrategiesUtils()
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

        public static Type GetStrategyByMovementStrategiesEnum(MovementStrategiesEnum strategiesEnum)
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