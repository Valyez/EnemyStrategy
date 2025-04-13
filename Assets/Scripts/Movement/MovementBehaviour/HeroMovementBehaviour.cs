namespace Movement.MovementBehaviour
{
    public class HeroMovementBehaviour : MovementBehaviour
    {
        public HeroMovementBehaviour()
        {
            _currentStrategy = new WASDStrategy();
        }

        public override void SwapStrategy(MovementStrategiesEnum newStrategy)
        {
            throw new System.NotImplementedException();
        }
    }
}