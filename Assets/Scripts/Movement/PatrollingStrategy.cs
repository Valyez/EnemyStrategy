using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PatrollingStrategy : MovementStrategy
    {
        private Queue<ControlPoint> _controlPointsQueue;
        private Vector3 _currentTarget;

        public void Move(GameObject gameObject)
        {
            if (_controlPointsQueue == null || _controlPointsQueue.Count == 0)
            {
                _controlPointsQueue = MovementUtils.GetControlPointList();
            }

            if (_currentTarget == Vector3.zero ||
                MovementUtils.GetDistanceToTarget(gameObject, _currentTarget) < Constant.MIN_DISTANCE_TO_TARGET)
            {
                _currentTarget = GetNewTarget();
            }
            
            Vector3 vectorToTarget = _currentTarget - gameObject.transform.position;
            MovementUtils.RotateToTarget(gameObject, vectorToTarget);
            MovementUtils.MoveToTarget(gameObject, vectorToTarget);
        }

        private Vector3 GetNewTarget()
        {
            return _controlPointsQueue.Dequeue().transform.position;
        }
    }
}