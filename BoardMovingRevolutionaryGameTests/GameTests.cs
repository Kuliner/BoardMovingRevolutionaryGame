using Xunit;

namespace BoardMovingRevolutionaryGame.Tests
{
    public class GameTests
    {
        [Theory()]
        [InlineData("2 2 E", "MRMLMRM")]
        [InlineData("3 2 N", "RMMMLMM")]
        [InlineData("0 4 N", "MMMMM")]
        public void GamePlayTest(string output, string input)
        {
            var game = new Game(5);
            Assert.Equal(output, game.PlayOut(input));
        }
    }
}