using System.Collections.Generic;
using static BoardMovingRevolutionaryGame.Defs.Enums;

namespace BoardMovingRevolutionaryGame
{
    public class Game : IPlay
    {
        private World _world;

        public Game(int mapSize)
        {
            _world = new World(mapSize);
        }

        public string PlayOut(string input)
        {
            var commands = PrepareCommands(input);

            foreach (var command in commands)
            {
                _world.Player.Move(command);
            }

            return _world.GetPlayerPosition(_world.Player);
        }

        private List<Command> PrepareCommands(string input)
        {
            var commands = new List<Command>();
            foreach (var letter in input)
            {
                switch (letter)
                {
                    case 'M':
                    case 'm':
                        commands.Add(Command.Move);
                        break;
                    case 'R':
                    case 'r':
                        commands.Add(Command.TurnRight);
                        break;
                    case 'L':
                    case 'l':
                        commands.Add(Command.TurnLeft);
                        break;
                }
            }

            return commands;
        }
    }
}
