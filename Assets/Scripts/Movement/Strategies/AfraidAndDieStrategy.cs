using System;
using Characters;
using UnityEngine;

namespace Movement
{
    public class AfraidAndDieStrategy : IMovementStrategy
    {
        public void Move(GameObject gameObject)
        {
            ICanDie canDie = gameObject.GetComponent<ICanDie>();

            if (canDie == null)
            {
                throw new Exception(Constant.NOT_IMPLEMENTING_ICANDIE_INTERFACE_EXCEPTION);
            }

            Vector3 localScale = gameObject.transform.localScale;

            if (localScale.x > Constant.DEFAULT_MIN_SCALE)
            {
                float reduceScaleDefaultStep = Constant.REDUCE_SCALE_DEFAULT_STEP * Time.deltaTime;
                gameObject.transform.localScale = new Vector3(
                    localScale.x - reduceScaleDefaultStep,
                    localScale.y - reduceScaleDefaultStep,
                    localScale.z - reduceScaleDefaultStep
                );
            }
            else
            {
                canDie.Die();
            }
        }
    }
}