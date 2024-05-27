class ConsoleUI
{
    public string ReadString(string query = "Enter input:")
    {
        while (true)
        {
            Write(query);

            string input = Console.ReadLine() ?? "";

            if (!String.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            else
            {
                Write("You can only enter letters or whitespace!");
            }
        }
    }

    public uint ReadUint(string query = "Enter number input:")
    {
        while (true)
        {
            string input = ReadString(query);
            if (uint.TryParse(input, out uint result) && result > 0)
            {
                return result;
            }
            else
            {
                Write("You need to input a positive number greater than zero!");
            }
        }
    }

    public void Write(string msg)
    {
        Console.WriteLine(msg);
    }
}
