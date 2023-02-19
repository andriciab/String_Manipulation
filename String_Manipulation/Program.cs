using System;
using System.Collections.Generic;

namespace String_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {         
            while (true)
            {
                displayMenu();

                // Get user option
                char userOption = Convert.ToChar(Console.ReadLine().ToLower());

                if (userOption == 'q')
                {
                    return;
                }

                // Prompt the user for a string
                printColorMessage(ConsoleColor.Yellow, "Please enter a string: ");
                
                string input = Console.ReadLine();

                // Perform operations on the given string until the user decides to stop 
                while (true)
                {
                    if (userOption == 'a')
                    {
                        input = convertToUpper(input);
                        printColorMessage(ConsoleColor.Yellow, $"Converted string: ");
                        Console.WriteLine($"{input}\n");
                    }
                    else if (userOption == 'b')
                    {
                        input = reverse(input);
                        printColorMessage(ConsoleColor.Yellow, $"Converted string: ");
                        Console.WriteLine($"{input}\n");
                    }
                    else if (userOption == 'c')
                    {
                        Console.WriteLine($"{countVowels(input)} vowels\n");
                    }
                    else if (userOption == 'd')
                    {
                        Console.WriteLine($"{countWords(input)} words\n");
                    }
                    else if (userOption == 'e')
                    {
                        input = convertToTitle(input);
                        printColorMessage(ConsoleColor.Yellow, $"Converted string: ");
                        Console.WriteLine($"{input}\n");
                    }
                    else if (userOption == 'f')
                    {
                        string answer = isPalindrome(input) ? $"The string {input} is palindrome\n" : $"The string {input} is not palindrome\n";
                        Console.WriteLine(answer);
                    }
                    else if (userOption == 'g')
                    {
                        longestShortest(input);
                    }
                    else if (userOption == 'h')
                    {
                        mostFrequent(input);
                    }

                    printColorMessage(ConsoleColor.Yellow,
                        "Please choose another option (or type \"m\" to go back to menu and enter another string)\n");

                    userOption = Convert.ToChar(Console.ReadLine().ToLower());

                    if (userOption == 'm')
                    {
                        Console.WriteLine("\n");
                        break;
                    }
                }
            }
        }

        static string convertToUpper(string text)
        {
            string transformedText = text.ToUpper();

            return transformedText;
        }

        static string reverse(string text)
        {
            string transformedText = "";

            for (int i = 0; i < text.Length; i++)
            {
                transformedText += text[text.Length - i - 1];
            }

            return transformedText;
        }

        static int countVowels(string text)
        {
            int numVowels = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if ("aeiouAEIOU".IndexOf(text[i]) >= 0)
                {
                    numVowels++;
                }
            }

            return numVowels;
        }

        static int countWords(string text)
        {
            // We will assume the user is a reasonable person and will enter a normal-formatted string,
            // with only one space between two words, and no spaces at the beginning or the end of the string
            int spaces = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    spaces++;
                }
            }

            int words = text.Length > 0 ? spaces + 1 : spaces;
            return words;
        }

        static string convertToTitle(string text)
        {
            string transformedText = "";

            transformedText += text[0].ToString().ToUpper();

            for (int i = 1; i < text.Length; i++)
            {
                // If the current character is a letter and preceded by a space, convert it to uppercase
                if (text[i] >= 65 && text[i] <= 122 && text[i - 1] == ' ')
                {
                    transformedText += text[i].ToString().ToUpper();
                }
                else
                {
                    transformedText += text[i].ToString().ToLower();
                }
            }

            return transformedText;
        }

        static bool isPalindrome(string text)
        {
            // We don't care if a character is uppercase or lowercase when cheking for palindrome,
            // so we'll convert the string to lowercase
            return text.ToLower() == reverse(text).ToLower();
        }

        static void longestShortest(string text)
        {
            // Split the given string in an array of strings
            string[] splitted = text.Split(' ');

            int longestWordIndex = 0;
            int shortestWordIndex = 0;

            int maxLength = 0;
            int minLength = int.MaxValue;

            // Iterate through the array and find the indexes of the longest and shortest words
            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i].Length > maxLength)
                {
                    maxLength = splitted[i].Length;
                    longestWordIndex = i;
                }
                if (splitted[i].Length < minLength)
                {
                    minLength = splitted[i].Length;
                    shortestWordIndex = i;
                }
            }
          
            printColorMessage(ConsoleColor.Yellow, "Longest word is: ");
            Console.WriteLine(splitted[longestWordIndex]);

            printColorMessage(ConsoleColor.Yellow, "Shortest word is: ");
            Console.WriteLine($"{splitted[shortestWordIndex]}\n");
        }

        static void mostFrequent(string text)
        {         
            int maxFrequency = 0;

            // We'll keep track of each word's number of appearances with a dictionary
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            // Split the given string in an array of strings
            string[] splitted = text.Split(' ');

            // If a certain word is already in the dictionary, increment its number of appearances
            // else, add it to the dictionary
            foreach (string word in splitted)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency.Add(word, 1);
                }
            }

            // Find the maximum number of appearances of a word
            foreach (var kvp in wordFrequency)
            {
                if (kvp.Value > maxFrequency)
                {
                    maxFrequency = kvp.Value;
                }
            }

            // Get the most frequent word 
            foreach (var kvp in wordFrequency)
            {
                if (kvp.Value == maxFrequency)
                {
                    printColorMessage(ConsoleColor.Yellow, "Most frequent word is: ");
                    Console.WriteLine($"{kvp.Key}\n");
                    return;
                }
            }
            // this is so inefficient it hurts me too
        }

        static void displayMenu()
        {
            printColorMessage(ConsoleColor.Yellow, "Please choose an option (or type \"q\" to quit the app):\n\n");
            Console.WriteLine("a. Convert to uppercase");
            Console.WriteLine("b. Reverse");
            Console.WriteLine("c. Count the number of vowels");
            Console.WriteLine("d. Count the number of words");
            Console.WriteLine("e. Convert to title case");
            Console.WriteLine("f. Check for palindrome");
            Console.WriteLine("g. Find the longest and shortest word");
            Console.WriteLine("h. Find the most frequent word\n");
        }

        static void printColorMessage(ConsoleColor color, string message)
        {
            // Change console text color 
            Console.ForegroundColor = color;

            Console.Write(message);

            Console.ResetColor();
        }
    }
}
