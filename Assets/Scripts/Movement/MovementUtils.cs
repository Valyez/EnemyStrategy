using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace Movement
{
    public static class MovementUtils
    {
        public static void MoveToTarget(GameObject gameObject, Vector3 vector)
        {
            gameObject.transform.position += new Vector3(vector.x,0,vector.z).normalized * (Constant.DEFAULT_SPEED * Time.deltaTime);
        }

        public static void RotateToTarget(GameObject gameObject, Vector3 vectorToTarget)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(vectorToTarget);
        }

        public static Vector3 GetRandomDirection()
        {
            return new Vector3(Random.Range(-100,100), 0, Random.Range(-100,100));
        }
        
        public static List<Hero> GetHeroList()
        {
            return new List<Hero>(Object.FindObjectsOfType<Hero>());
        }
        
        public static Queue<ControlPoint> GetControlPointList()
        {
            return new Queue<ControlPoint>(Object.FindObjectsOfType<ControlPoint>());
        }
        
        public static float GetDistanceToTarget(GameObject gameObject,Vector3 target2 )
        {
            return (gameObject.transform.position - target2).magnitude;
        }
    }
}