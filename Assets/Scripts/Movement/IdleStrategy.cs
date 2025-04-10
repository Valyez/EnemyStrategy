using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement
{
    public class IdleStrategy: IMovementStrategy
    {
        public void Move(GameObject gameObject)
        {
            //do nothing
        }

        public void Initialize(ControlPointsHolder controlPointsHolder, Hero hero)
        {
            //Do nothing
        }
    }
}