namespace ASeriesExercise;

internal class A02 {
    internal void StartGuessGame() {
        int number = new Random().Next(1, 101);
        for (; ; ) {
            Console.Write("What is your guess ?  ");
            if (int.TryParse(Console.ReadLine(), out int guess) && guess is > 0 and <= 100) {
                if (guess > number) Console.WriteLine("Your guess is too high");
                else if (guess < number) Console.WriteLine("Your guess is too low");
                else {
                    Console.WriteLine("You guessed correctly");
                    break;
                }
            }
            else Console.WriteLine("Please enter a number between 1 to 100.");
        }
    }

    internal void AverageGuessesValue() {
        int count = 0;
        int min = 1, max = 100;
        for (int i = min; i < max; i++) {
            int low = min, high = max, guess;
            while (true) {
                count++;
                guess = (low + high) / 2;
                if (guess > i) high = guess;
                else if (guess < i) low = guess;
                else break;
            }
        }
        Console.WriteLine((double)count / (max - min));
    }

    internal void StartGuessMyNumber() {
        int high = 100;
        int low = 1;
        for (; ; ) {
            int guess = (low + high) / 2;
            Console.Write($"My guess is {guess}. Is it high/ low/ correct ?  ");
            switch (Console.ReadLine()) {
                case "high": high = guess;
                    break;
                case "low": low = guess; 
                    break;
                case "correct": Console.WriteLine("Yay! I guessed it right"); 
                    return;
                default: Console.WriteLine("Please mention high, low or correct"); 
                    break;
            }
        }
    }

}
