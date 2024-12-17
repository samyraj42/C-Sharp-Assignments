using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASeriesExercise;
public class A04 {
    public void GetLetterFrequency() {
        string filePath = "words.txt";
        string[] words = File.ReadAllLines(filePath);
        
        Dictionary<char, int> letterFreq = [];
        for (char c = 'A'; c >= 'A' && c <= 'Z'; c++) letterFreq[c] = 0;
        
        foreach(var word in words)
            foreach (var letter in word.ToUpper().Distinct())
                letterFreq[letter]++;

        foreach (var letter in letterFreq.OrderByDescending(e => e.Value).Take(7))
            Console.WriteLine($"The frequency of letter {letter.Key} is {letter.Value}");
    }
}

