using Characters;
using UnityEngine;

namespace Movement
{
    public class ChaseStrategy : IMovementStrategy
    {
        private Hero _hero;

        public ChaseStrategy(Hero hero)
        {
            _hero = hero;
        }

        public void Move(GameObject gameObject)
        {
            Vector3 vectorToHero = _hero.transform.position - gameObject.transform.position;

            MovementUtils.RotateToTarget(gameObject, vectorToHero);
            MovementUtils.MoveToTarget(gameObject, vectorToHero);
        }
    }
}