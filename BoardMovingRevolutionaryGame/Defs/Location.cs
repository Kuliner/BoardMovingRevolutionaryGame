using System;

namespace BoardMovingRevolutionaryGame
{
    public class Location
    {
        public Action LocationValueChanged;

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        private int x;
        public int X
        {
            get => x;
            set
            {
                x = value;
                LocationValueChanged?.Invoke();
            }
        }

        private int y;
        public int Y
        {
            get => y;
            set
            {
                y = value;
                LocationValueChanged?.Invoke();
            }
        }

        public Location TransformCoordinates(int mapConstraint)
        {
            return new Location(X, mapConstraint - Y);
        }
    }
}