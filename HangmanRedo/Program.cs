using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanRedo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER YOUR NAME");
            var playerName = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine("HELLO, " + playerName + ". LET US PLAY HANGMAN.");
            Console.WriteLine("I WILL PICK A WORD.");
            Console.WriteLine("YOU WILL SEE A SERIES OF BLANK SPACES.");
            Console.WriteLine("YOU MUST GUESS WHAT THE WORD IS.");
            Console.WriteLine("EACH LETTER YOU GUESS WILL BE TESTED.");
            Console.WriteLine("IF THAT LETTER IS IN THE WORD, IT WILL REPLACE THE LINE.");
            Console.WriteLine("IF IT IS NOT, THEN YOU WILL LOSE A CHANCE.");
            Console.WriteLine("WHEN YOUR CHANCES REACH ZERO, YOU LOSE.");
            Console.WriteLine("IF YOU REVEAL ALL THE LETTERS OR GUESS THE WORD, YOU WIN.");
            Console.WriteLine("GOOD LUCK.");
            Console.Clear();

            bool playing = true;

            while (playing == true)
            {
                RunGame();

                Console.WriteLine("WOULD YOU LIKE TO PLAY AGAIN?");

                var replay = Console.ReadLine().ToString().ToLower();

                if (replay == "no")
                {
                    playing = false;
                }
            }
        }
        static void RunGame()
        {
            string[] words = { "moscow", "godzilla", "guava", "antelope", "waldo" };

            var random = new Random();

            int number = random.Next(0, words.Length);

            string picked = words[number].ToUpper();

            var lettersGuessed = new List<string>();

            int guessesLeft = 6;

            bool wordRight = false;

            //while(wordRight == false && guessesLeft > 0)
            //{
            //    Masked(lettersGuessed, picked);
            //    Console.WriteLine(lettersGuessed);
            //    Console.WriteLine(guessesLeft);
            //
            //    Console.WriteLine("PLEASE MAKE A GUESS.");
            //    var playerGuess = Console.ReadLine().ToString().ToUpper();
            //
            //    if (playerGuess.Length > 1)
            //    {
            //        if (playerGuess.ToString().ToUpper() == picked.ToString().ToUpper())
            //        {
            //            YouWon();
            //        }
            //        else
            //        {
            //            guessesLeft--;
            //        }
            //    }
            //    else
            //    {
            //        lettersGuessed.Add(playerGuess);
            //    }
            //}
            if (guessesLeft == 0)
            {
                YouLose();
            }
        }
        static void Masked(List<string> lettersGuessed, string theWord)
        {
            string returnString = "";

            int i = 0;

            bool foundALetter = false;

            while (i < theWord.Length)
            {
                var letter = theWord[i].ToString();

                foreach (var guess in lettersGuessed)
                {
                    if (guess == letter)
                    {
                        foundALetter = true;
                    }
                }

                if (foundALetter)
                {
                    returnString += letter;
                }

                else
                {
                    returnString += "_";
                }

                i++;
            }

            Console.Write(returnString);
        }
        static void YouWon()
        {
            Console.WriteLine("GOOD WORK");
            Console.WriteLine("YOU HAVE GUESSED THE WORD CORRECTLY");
        }
        static void YouLose()
        {
            Console.WriteLine("YOU HAVE RUN OUT OF GUESSES");
            Console.WriteLine("TOO BAD, BUT YOU HAVE LOST");
        }
    }
}
