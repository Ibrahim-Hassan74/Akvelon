namespace Akvelon
{
    public class FizzBuzzDetector
    {
        public FizzBuzzResult GetOverlappings(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            string[] lines = text.Split('\n');
            int wordCount = 0;
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(' ');

                for (int j = 0; j < tokens.Length; j++)
                {
                    if (ContainsAlphanumeric(tokens[j]))
                    {
                        wordCount++;
                        tokens[j] = Detect(wordCount, tokens[j]);

                        if (wordCount % 3 == 0 || wordCount % 5 == 0)
                            count++;
                    }
                }

                lines[i] = string.Join(" ", tokens);
            }

            return new FizzBuzzResult
            {
                OutputString = string.Join("\n", lines),
                Count = count
            };
        }

        private string Detect(int number, string text)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return text;
            }
        }

        private bool ContainsAlphanumeric(string token)
        {
            for (int i = 0; i < token.Length; i++)
            {
                char c = token[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
                    return true;
            }
            return false;
        }
    }
}
