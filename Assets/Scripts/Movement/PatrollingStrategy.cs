using System;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PatrollingStrategy : MonoBehaviour, MovementStrategy
    {
        private List<ControlPoint> _controlPointsList;

        
            ControlPoint[] controlPoints = Resources.FindObjectsOfTypeAll<ControlPoint>();
        

        public void Move(GameObject gameObject)
        {
        }
    }
}