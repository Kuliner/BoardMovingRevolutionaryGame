using System;
using System.Text;
using static BoardMovingRevolutionaryGame.Defs.Enums;

namespace BoardMovingRevolutionaryGame
{
    public class World : IDisposable
    {
        private readonly int _mapSize;
        private readonly char[,] _map;

        public Player Player { get; set; }

        public World(int mapSize)
        {
            _mapSize = mapSize;
            _map = new char[mapSize, mapSize];

            Player = new Player(0, _mapSize - 1);
            Player.LocationChanged += PlayerLocationChangedHandler;

            InitializeMap(mapSize);
        }

        public string GetPlayerPosition(Player player)
        {
            var playerLocation = player.Location.TransformCoordinates(_mapSize - 1);
            return playerLocation.X + " " + playerLocation.Y + " " + GetDirectionAbbreviation(player.Direction);
        }

        public void Dispose()
        {
            Player.LocationChanged -= PlayerLocationChangedHandler;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _mapSize; i++)
            {
                for (int k = 0; k < _mapSize; k++)
                {
                    stringBuilder.Append(_map[i, k]);
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
        
        private void PlayerLocationChangedHandler(Player player)
        {
            var mapSizeConstraint = _mapSize - 1;

            if (player.Location.X > mapSizeConstraint)
                player.Location.X = mapSizeConstraint;

            if (player.Location.X < 0)
                player.Location.X = 0;
            
            if (player.Location.Y > mapSizeConstraint)
                player.Location.Y = mapSizeConstraint;

            if (player.Location.Y < 0)
                player.Location.Y = 0;
        }

        private void InitializeMap(int mapSize)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int k = 0; k < mapSize; k++)
                {
                    _map[i, k] = 'x';
                }
            }
        }

        private char GetDirectionAbbreviation(Direction direction)
        {
            return direction switch
            {
                Direction.North => 'N',
                Direction.South => 'S',
                Direction.East => 'E',
                Direction.West => 'W',
                _ => ' ',
            };
        }
    }
}
