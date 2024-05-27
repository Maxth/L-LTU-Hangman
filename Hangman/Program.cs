// See https://aka.ms/new-console-template for more information

FileHandler fileHandler = new FileHandler();

string rawWords = fileHandler.ReadFile(@"assets/Hangman_wordbank");

Main main = new Main(rawWords.Split(", "), new ConsoleUI());

main.RunGame();
