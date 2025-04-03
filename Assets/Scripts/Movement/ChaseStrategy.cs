using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Movement
{
    public class ChaseStrategy : MovementStrategy
    {
        private static List<Hero> _allHeroes;

        public void Move(GameObject gameObject)
        {
            if (_allHeroes == null)
            {
                _allHeroes = MovementUtils.GetHeroList();
            }

            if (_allHeroes.Count == 0)
            {
                //do nothing
            }
            else
            {
                Vector3 currentDirection = Vector3.positiveInfinity;

                foreach (Hero hero in _allHeroes)
                {
                    Vector3 vectorToHero = hero.transform.position - gameObject.transform.position;

                    if (currentDirection.magnitude > vectorToHero.magnitude)
                    {
                        currentDirection = vectorToHero;
                    }
                }

                MovementUtils.RotateToTarget(gameObject, currentDirection);
                MovementUtils.MoveToTarget(gameObject, currentDirection);
            }
        }
    }
}