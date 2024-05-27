class Game(string correctWord, Player[] players, ConsoleUI cui)
{
    private string _correctWord = correctWord.ToUpper();
    public Player[] Players { get; private set; } = players;

    private ConsoleUI _cui = cui;

    internal void Run()
    {
        bool gameActive = true;
        int playersLeft = Players.Length;
        while (gameActive && playersLeft > 0)
        {
            _cui.Write("New round of guesses!");
            foreach (Player player in Players)
            {
                if (player.GuessesLeft > 0)
                {
                    _cui.Write($"It is {player.Name}'s turn.");
                    _cui.Write(
                        $"Progress: {new string(player.Progress)}. Guesses left: {player.GuessesLeft}"
                    );
                    HandleGuess(player);

                    //Check if player won
                    if (
                        new String(player.Progress).Equals(
                            _correctWord,
                            StringComparison.CurrentCultureIgnoreCase
                        )
                    )
                    {
                        _cui.Write($"Congratulations {player.Name}! You won!");
                        gameActive = false;
                        break;
                    }
                    if (player.GuessesLeft == 0)
                    {
                        _cui.Write($"You lost {player.Name}. You used all your 10 guesses.");
                        playersLeft--;
                    }
                }
            }
        }
    }

    private void HandleGuess(Player player)
    {
        while (true)
        {
            string guess = _cui.ReadString($"Enter your guess, {player.Name}!");
            //If the player guesses the correct word
            if (guess.Equals(_correctWord, StringComparison.CurrentCultureIgnoreCase))
            {
                for (int i = 0; i < player.Progress.Length; i++)
                {
                    player.Progress[i] = _correctWord[i];
                }
                break;
            }
            //If the player guesses an incorrect word,
            //or guesses a letter not in the correctword or in the player's previous guesses
            if (
                guess.Length > 1
                || (
                    !_correctWord.Contains(guess, StringComparison.CurrentCultureIgnoreCase)
                    && !player
                        .GetPreviousGuesses()
                        .Contains(guess, StringComparison.CurrentCultureIgnoreCase)
                )
            )
            {
                player.HandleIncorrectGuess(guess);
                _cui.Write("That guess is incorrect!");
                break;
            }
            //If the player guesses a letter that is in the player's previous guesses.
            if (
                player
                    .GetPreviousGuesses()
                    .Contains(guess, StringComparison.CurrentCultureIgnoreCase)
            )
            {
                _cui.Write("You already guessed that letter, try again!");
                continue;
            }
            //If the player guesses a letter that is in the correct word
            else
            {
                _cui.Write("That letter is in the secret word!");
                player.GuessesLeft--;
                for (int i = 0; i < player.Progress.Length; i++)
                {
                    if (_correctWord[i] == char.ToUpper(guess[0]))
                    {
                        player.Progress[i] = char.ToUpper(guess[0]);
                    }
                }
                _cui.Write($"{new string(player.Progress)}  Press enter to continue");
                Console.Read();
                break;
            }
        }
    }
}
