﻿using System;
using System.Collections.Generic;

class Program
{
    static List<string> MakeHiddenWord(string theWord)
    {
        // Initialize de dolda ordet
        List<string> hiddenWord = new List<string>();

        // Loopar igenom varje tecken i ordet och lägg till ett understreck i listan
        for (int i = 0; i < theWord.Length; i++)
        {
            hiddenWord.Add("_");
        }

        return hiddenWord;
    }

    static void Main()
    {
        // Game setup
        int lives = 7;
        List<string> wrongGuesses = new List<string>();
        string word = "Pankaka";
        List<string> hiddenWords = MakeHiddenWord(word);

        // Main game loop
        while (wrongGuesses.Count < lives && string.Join("", hiddenWords) != word)
        {
            // Display the current state of the hidden word
            Console.WriteLine(string.Join(" ", hiddenWords));

            // guess
            Console.Write("Enter a guess: ");
            string guess = Console.ReadLine().ToLower(); //bara gjorde så det är littet

            // kollar om ordet finns
            if (word.ToLower().Contains(guess))
            {
                Console.WriteLine("Yes");

                // vissar ordet
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString().ToLower() == guess) 
                    {
                        hiddenWords[i] = word[i].ToString();
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
                wrongGuesses.Add(guess);
            }
            // Kollar om user har namnet rätt helt
            if (string.Join("", hiddenWords) == word)
            {
                Console.WriteLine("You won!");
                break; // Exit the loop för du van
            }
        }

        Console.WriteLine("Game Is Over");
        Console.ReadLine();
    }
}
