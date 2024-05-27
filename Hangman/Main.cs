class Main(string[] wordBank, ConsoleUI cui)
{
    private static readonly Random _r = new Random();
    private readonly string[] _wordBank = wordBank;

    private ConsoleUI _cui = cui;

    public void RunGame()
    {
        _cui.Write("Welcome to Hangman!");
        uint playerCount = _cui.ReadUint("How many players?");
        Player[] players = new Player[playerCount];
        string correctWord = _wordBank[_r.Next(_wordBank.Length)];
        for (int i = 0; i < playerCount; i++)
        {
            players[i] = new Player(
                _cui.ReadString($"What's the name of player {i + 1}"),
                new char[correctWord.Length]
            );
        }
        _cui.Write("Starting game...");
        Game game = new Game(correctWord, players, _cui);
        game.Run();

        bool playAgain =
            _cui.ReadString("Good game! Press \"a\" to play again, any other key to exit!") == "a";

        if (playAgain)
        {
            RunGame();
        }
        else
        {
            Environment.Exit(0);
        }
    }
}
