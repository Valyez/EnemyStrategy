using Characters;
using DefaultNamespace;
using UnityEngine;

namespace Movement
{
    public class WASDStrategy : IMovementStrategy
    {
        public void Move(GameObject gameObject)
        {
            float horizontal = Input.GetAxisRaw(Constant.HORIZONTAL_AXIS_NAME);
            float vertical = Input.GetAxisRaw(Constant.VERTICAL_AXIS_NAME);

            Vector3 inputVector =
                new Vector3(
                    horizontal * (Constant.HERO_SPEED * Time.deltaTime),
                    0,
                    vertical * (Constant.HERO_SPEED * Time.deltaTime));

            if (inputVector.magnitude > Constant.MIN_INPUT_DISTANCE)
            {
                MovementUtils.RotateToTarget(gameObject, inputVector);
                MovementUtils.MoveToTarget(gameObject, inputVector);
            }
        }
    }
}