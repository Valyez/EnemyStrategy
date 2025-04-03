using UnityEngine;

namespace Movement
{
    public class RunAwayStrategy : MovementStrategy
    {
        public void Move(GameObject gameObject)
        {
            Hero[] heroes = Resources.FindObjectsOfTypeAll<Hero>();
            if (heroes.Length == 0)
            {
                //do nothing
            }
            else
            {
                Vector3 currentDirection = new Vector3();

                foreach (Hero hero in heroes)
                {
                    currentDirection += gameObject.transform.position - hero.transform.position;
                }

                MovementUtils.RotateToTarget(gameObject, currentDirection);
                MovementUtils.MoveToTarget(gameObject, currentDirection);
            }
        }
    }
}