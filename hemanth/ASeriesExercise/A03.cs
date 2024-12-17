using static System.Formats.Asn1.AsnWriter;

namespace ASeriesExercise;

class A03 {
    internal void StartGuessMyNumber() {
        int number = 0;
        int divider = 2;
        int reminder = 1;
        for (int i = 0; i < 7; i++) {
            ConsoleKey input;
            Console.Write($"When divided by {divider} is reminder {reminder}? (Y/N): ");
            do input = Console.ReadKey(true).Key; 
            while (input != ConsoleKey.Y && input != ConsoleKey.N);

            if (input == ConsoleKey.Y) number += divider / 2;
            else reminder -= divider / 2;
            Console.WriteLine(input);
            reminder += divider;
            divider *= 2;
        }
        Console.WriteLine($"Your number is {number}");
    }

    internal void SpellingBee() {
        // Link for words.txt in exercise is inaccessible.
        // Collected words from different source.
        string filePath = "words.txt";
        string[] words = File.ReadAllLines(filePath);
        var validWords = new (int, string, bool)[words.Length];
        char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
        // Find valid words and score them
        for (int i = 0; i < words.Length; i++) {
            if (words[i].Length < 4) continue;
            string word = words[i].ToUpper();
            if (word.Contains(letters[0]) && word.All(c => letters.Contains(c)))
                if (word.Length == 4)
                    validWords[i] = (1, word, false);
                else if (letters.All(word.Contains))
                    validWords[i] = (word.Length + 7, word, true);
                else validWords[i] = (word.Length, word, false);
        }
        var orderedWords = validWords.Where(t => t.Item1 != 0)
                                     .OrderByDescending(t => t.Item1).ToArray();
        int total = 0; // Sum scores and print the valid words
        foreach (var word in orderedWords) {
            total += word.Item1;
            if (word.Item3) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{word.Item1,2}. {word.Item2}");
                Console.ResetColor();
            }
            else Console.WriteLine($"{word.Item1,2}. {word.Item2}");
        }
        Console.WriteLine("----");
        Console.WriteLine($"{total} total");
    }
}
