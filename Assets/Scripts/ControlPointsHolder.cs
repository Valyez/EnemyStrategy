using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ControlPointsHolder : MonoBehaviour
    {
        private List<ControlPoint> _controlPointsList;

        public List<ControlPoint> ControlPointsList => _controlPointsList;

        private void Awake()
        {
            _controlPointsList = new List<ControlPoint>(gameObject.GetComponentsInChildren<ControlPoint>());
        }
    }
}