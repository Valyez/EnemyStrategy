﻿using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Movement
{
    public class RunAwayStrategy : MovementStrategy
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
                Vector3 currentDirection = new Vector3();

                foreach (Hero hero in _allHeroes)
                {
                    currentDirection += gameObject.transform.position - hero.transform.position;
                }

                MovementUtils.RotateToTarget(gameObject, currentDirection);
                MovementUtils.MoveToTarget(gameObject, currentDirection);
            }
        }
    }
}