using System.Collections.Generic;
using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement
{
    public class RunAwayStrategy : IMovementStrategy
    {
        private Hero _hero;

        public RunAwayStrategy(Hero hero)
        {
            _hero = hero;
        }

        public void Move(GameObject gameObject)
        {
            Vector3 currentDirection = new Vector3();
            currentDirection += gameObject.transform.position - _hero.transform.position;
            
            MovementUtils.RotateToTarget(gameObject, currentDirection);
            MovementUtils.MoveToTarget(gameObject, currentDirection);
        }
    }
}