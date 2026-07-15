int seconds = ReadSeconds();
await RunCountdownAsync(seconds);

static int ReadSeconds()
{
    const int defaultSeconds = 5;
    while (true)
    {
        Console.Write($"Enter countdown seconds (default {defaultSeconds}): ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return defaultSeconds;
        }
        if (int.TryParse(input, out int value) && value > 0)
        {
            return value;
        }
        Console.WriteLine("Please enter an integer greater than 0.");
    }
}

static async Task RunCountdownAsync(int seconds)
{
    for (int remaining = seconds; remaining >= 0; remaining--)
    {
        var time = TimeSpan.FromSeconds(remaining);
        Console.Write($"\rTime remaining: {time:hh\\:mm\\:ss}   ");
        await Task.Delay(1000);
    }

    Console.WriteLine();
    Console.WriteLine("Time's up!");
    Console.Beep();
}
