using System.Collections.Generic;
using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement
{
    public class ChaseStrategy : IMovementStrategy
    {
        private static Hero _hero;

        public void Move(GameObject gameObject)
        {
            Vector3 vectorToHero = _hero.transform.position - gameObject.transform.position;

            MovementUtils.RotateToTarget(gameObject, vectorToHero);
            MovementUtils.MoveToTarget(gameObject, vectorToHero);
        }

        public void Initialize(ControlPointsHolder controlPointsHolder, Hero hero)
        {
            _hero = hero;
        }
    }
}