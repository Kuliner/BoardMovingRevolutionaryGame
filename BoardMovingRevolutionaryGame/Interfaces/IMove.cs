using static BoardMovingRevolutionaryGame.Defs.Enums;

namespace BoardMovingRevolutionaryGame
{
    public interface IMove
    {
        void Move(Command command);
    }
}