using Characters;
using DefaultNamespace;
using UnityEngine;

public interface IMovementStrategy
{
   public void Move(GameObject gameObject);
   void Initialize(ControlPointsHolder controlPointsHolder, Hero hero);
}