using Akvelon;

try
{
    Console.Write("Enter the text and press Ctrl+Z then Enter for EOF: ");

    string input = Console.In.ReadToEnd();

    Console.WriteLine();
    var detector = new FizzBuzzDetector();

    var result = detector.GetOverlappings(input);

    Console.WriteLine("output string:");
    Console.WriteLine(result.OutputString);
    Console.WriteLine();
    Console.WriteLine($"count: {result.Count}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
