using System.Collections.Generic;
using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement
{
    public class PatrollingStrategy : IMovementStrategy
    {
        private Queue<ControlPoint> _controlPointsQueue;
        private ControlPointsHolder _controlPointsHolder;
        private Vector3 _currentTarget;

        public void Move(GameObject gameObject)
        {
            if ( _controlPointsQueue.Count == 0)
            {
                UpdateControlPointQueue();
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

        public void Initialize(ControlPointsHolder controlPointsHolder, Hero hero)
        {
            _controlPointsHolder = controlPointsHolder;
            _controlPointsQueue = new Queue<ControlPoint>();
            UpdateControlPointQueue();
        }

        private void UpdateControlPointQueue()
        {
            List<ControlPoint> controlPointsList = _controlPointsHolder.ControlPointsList;
            foreach (ControlPoint controlPoint in controlPointsList)
            {
                _controlPointsQueue.Enqueue(controlPoint);
            }
        }

        private Vector3 GetNewTarget()
        {
            return _controlPointsQueue.Dequeue().transform.position;
        }
    }
}