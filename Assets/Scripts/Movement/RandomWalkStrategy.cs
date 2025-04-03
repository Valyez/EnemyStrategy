using UnityEngine;

namespace Movement
{
    public class RandomWalkStrategy : MovementStrategy
    {
        private Vector3 _direction;
        private float _timer;

        public void Move(GameObject gameObject)
        {
            _timer += Time.deltaTime;

            if (_timer > Constant.RANDOM_MOVE_TIMER_COOLDOWN)
            {
                _timer = 0;
                _direction = MovementUtils.GetRandomDirection();
            }

            MovementUtils.RotateToTarget(gameObject, _direction);
            MovementUtils.MoveToTarget(gameObject, _direction);
        }
    }
}