using System;
using static BoardMovingRevolutionaryGame.Defs.Enums;

namespace BoardMovingRevolutionaryGame
{
    public class Player : IMove, IDisposable
    {
        public Action<Player> LocationChanged;

        public Direction Direction { get; set; } = Direction.North;

        private Location _location;
        public Location Location
        {
            get => _location;
            set
            {
                _location = value;
                LocationChanged?.Invoke(this);
            }
        }

        public Player(int x, int y)
        {
            _location = new Location(x, y);
            _location.LocationValueChanged += LocationValueChangedHandler;
        }

        public void Move(Command command)
        {
            switch (command)
            {
                case Command.Move:
                    MoveForward();
                    break;
                case Command.TurnLeft:
                    TurnLeft();
                    break;
                case Command.TurnRight:
                    TurnRight();
                    break;
            }
        }

        public void Dispose()
        {
            _location.LocationValueChanged -= LocationValueChangedHandler;
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    Location.Y -= 1;
                    break;
                case Direction.South:
                    Location.Y += 1;
                    break;
                case Direction.East:
                    Location.X += 1;
                    break;
                case Direction.West:
                    Location.X -= 1;
                    break;
            }
        }

        private void LocationValueChangedHandler()
        {
            LocationChanged?.Invoke(this);
        }
    }
}
