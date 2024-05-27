using System.Text;

class Player
{
    private StringBuilder previousIncorrectGuesses = new StringBuilder("", 10);

    public char[] Progress { get; set; }

    public string Name { get; }

    public uint GuessesLeft { get; set; } = 10;

    public Player(string name, char[] startingProgress)
    {
        Array.Fill(startingProgress, '_');
        Progress = startingProgress;
        Name = name;
    }

    internal void HandleIncorrectGuess(string guess)
    {
        GuessesLeft--;
        if (guess.Length == 1)
        {
            previousIncorrectGuesses.Append(char.ToUpper(guess[0]));
        }
    }

    internal string GetPreviousGuesses()
    {
        return previousIncorrectGuesses.ToString();
    }
}
