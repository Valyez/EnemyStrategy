using Movement.MovementBehaviour;

namespace Characters
{
    public class Hero : Character
    {
        private void Awake()
        {
             movementBehaviour = new HeroMovementBehaviour();
        }
    }
}