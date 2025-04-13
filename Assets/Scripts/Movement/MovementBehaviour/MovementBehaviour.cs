using UnityEngine;

namespace Movement.MovementBehaviour
{
    public abstract class MovementBehaviour
    {
        protected IMovementStrategy _currentStrategy;

        public void Move(GameObject gameObject)
        {
            if (_currentStrategy != null)
            {
                _currentStrategy.Move(gameObject);
            }
        }

        public abstract void SwapStrategy(MovementStrategiesEnum newStrategy);
    }
}