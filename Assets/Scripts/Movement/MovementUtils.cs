using UnityEngine;

namespace Movement
{
    public static class MovementUtils
    {
        public static void MoveToTarget(GameObject gameObject, Vector3 vector)
        {
            gameObject.transform.position += vector.normalized * (Constant.DEFAULT_SPEED * Time.deltaTime);
        }

        public static void RotateToTarget(GameObject gameObject, Vector3 vectorToTarget)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(vectorToTarget);
        }
    }
}