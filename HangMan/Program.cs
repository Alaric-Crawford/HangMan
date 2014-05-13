using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan
{
    class Program
    {
        static string PlayerName = "";
        static string wordPicked;
        static int guessesBegin = 12;
        static int guessesRemaining = guessesBegin;
        static List<string> letterGuess = new List<string>();
        static string playerGuess;
        static bool uWin = false;
        static List<bool> boolFace = new List<bool>();

        static void GameHangmen()
        {
            WouldYouLikeToPlay();
            Console.Clear();

            bool playing = true;
            while (playing == true)
            {
                CategoryPick();
                do
                {
                    Working();
                } while (uWin == false && guessesRemaining > 0);

                if (uWin)
                {
                    Congrats();
                }
                else
                {
                    TooBad();
                }
                TextPrint("Would you like to play again?");
                var replay = Console.ReadLine().ToString().ToLower();

                if (replay == "no")
                {
                    playing = false;
                }
                else
                {
                    playing = true;
                }
            }
            TextPrint("Thank you for playing. I hope to see you again sometime.");
        }
        static void WouldYouLikeToPlay()
        {
            TextPrint("Hello. Shall we play a game?");
            Thread.Sleep(1500);
            Console.Clear();
            TextPrint("Before we begin, I must ask for your name.");

            PlayerName = Console.ReadLine().ToString();

            Console.Clear();

            TextPrint("Very well, " + PlayerName + ".");
            Thread.Sleep(500);
            TextPrint("Let us begin.");
            Thread.Sleep(1000);
            TextPrint("First, you must choose a category.");
            Thread.Sleep(500);
            TextPrint("Once you have chosen, I will select a word randomly within that category.");
            Thread.Sleep(500);
            TextPrint("You will have to guess the letters or the word.");
            Thread.Sleep(500);
            TextPrint("If your guess is wrong, you will lose a guess.");
            Thread.Sleep(500);
            TextPrint("If your guesses run down to zero, you will have lost.");
            Thread.Sleep(500);
            TextPrint("If the letter you guess is within the word, they will replace the placeholder.");
            Thread.Sleep(500);
            TextPrint("If you guess the word, you will win.");
            Thread.Sleep(1000);
            Console.Clear();

        }
        static void CategoryPick()
        {
            TextPrint("Choose your category, " + PlayerName + ": Food, Creature, or Random Information.");
            var category = Console.ReadLine();
            category = category.ToLower();
            Thread.Sleep(1000);
            Console.Clear();
            Processing();

            if (category == "food")
            {
                FigureOutWordFood();
            }
            if (category == "creature")
            {
                FigureOutWordCreature();
            }
            if (category == "random information" || category == "randon" || category == "information" || category == "random info")
            {
                FigureOutWordOther();
            }
        }
        static void FigureOutWordFood()
        {
            string[] FoodBank = { "sandwich", "banana", "ramen", "soup", "hazelnut", "enchiladas", "naan" };
            Random noPattern = new Random();

            int patternIndex = noPattern.Next(0, FoodBank.Length);

            wordPicked = FoodBank[patternIndex].ToUpper();

            Thread.Sleep(100);
            TextPrint("The word has been chosen.");
            Thread.Sleep(1200);

            var hidden = new List<string>();
            for (int i = 0; i < wordPicked.Length; i++)
            {
                hidden.Add("|| ");
            }
            for (int i = 0; i < wordPicked.Length; i++)
            {
                Console.Write(hidden[i]);
                Thread.Sleep(50);
            }
            ReviewAndAnalyze();
        }
        static void FigureOutWordCreature()
        {
            string[] cryptoZoo = { "godzilla", "yaoguai", "chimera", "doppelganger", "imoogi", "banshee", "sharktopus", "kraken", "roc" };
            Random noPattern = new Random();

            int patternIndex = noPattern.Next(0, cryptoZoo.Length);

            wordPicked = cryptoZoo[patternIndex].ToUpper();

            Thread.Sleep(100);
            TextPrint("The word has been chosen.");
            Thread.Sleep(1200);

            var hidden = new List<string>();
            for (int i = 0; i < wordPicked.Length; i++)
            {
                hidden.Add("|| ");
            }
            for (int i = 0; i < wordPicked.Length; i++)
            {
                Console.Write(hidden[i]);
                Thread.Sleep(50);
            }
            ReviewAndAnalyze();
        }
        static void FigureOutWordOther()
        {
            string[] random = { "moose", "lavender", "leotard", "vocaloid", "osprey", "moscow" };
            Random noPattern = new Random();

            int patternIndex = noPattern.Next(0, random.Length);

            wordPicked = random[patternIndex].ToUpper();

            Thread.Sleep(100);
            TextPrint("The word has been chosen.");
            Thread.Sleep(1200);

            var hidden = new List<string>();
            for (int i = 0; i < wordPicked.Length; i++)
            {
                hidden.Add("|| ");
            }
            for (int i = 0; i < wordPicked.Length; i++)
            {
                Console.Write(hidden[i]);
                Thread.Sleep(50);
            }
            ReviewAndAnalyze();
        }
        static void ReviewAndAnalyze()
        {
            Console.WriteLine();
            TextPrint("Enter your guess");

            playerGuess = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Processing();
            Console.Clear();

            if (playerGuess.Length > 1)
            {
                if (playerGuess.ToString() == wordPicked.ToString())
                {
                    TextPrint("That is the word.");
                    uWin = true;
                }
                else
                {
                    guessesRemaining -= 1;
                    TextPrint("That is not the word.");
                    Thread.Sleep(100);
                    TextPrint("Press a key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            if (playerGuess.Length == 1)
            {
                letterGuess.Add(playerGuess);
            }

            bool IsItThere = false;
            for (int i = 0; i < wordPicked.Length; i++)
            {
                char b = wordPicked[i];
                if (playerGuess.Where(x => x == b).Any())
                {
                    IsItThere = true;
                }
            }

            if (!IsItThere)
            {
                guessesRemaining -= 1;
                TextPrint("That is not within parameters.");
                Thread.Sleep(1000);
            }
            else
            {
                TextPrint("That is within parameters.");
                Thread.Sleep(1000);
            }

            Console.Clear();

            if (TryLetters())
            {
                uWin = true;
            }
        }
        static bool TryLetters()
        {
            boolFace.Clear();

            for (int i = 0; i < wordPicked.Length; i++)
            {
                if (letterGuess.Where(x => x == wordPicked[i].ToString()).Any())
                {
                    boolFace.Add(true);
                }
                else
                {
                    boolFace.Add(false);
                }
            }

            if (boolFace.Where(i => i == false).Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Working()
        {
            TextPrint("Here is what you have, " + PlayerName + ":");
            Console.WriteLine();

            PlayTime();

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("You have Guessed: ");
            for (int i = 0; i < letterGuess.Count; i++)
            {
                Console.Write(letterGuess[i] + ' ');
            } Console.WriteLine();

            TextPrint("Guesses remaining: " + guessesRemaining);

            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine();

            ReviewAndAnalyze();
        }
        static void PlayTime()
        {
            for (int i = 0; i < wordPicked.Length; i++)
            {
                string z = wordPicked[i].ToString();
                if (letterGuess.Where(x => x == z).Any())
                {
                    Console.Write(wordPicked[i] + " ");
                    Thread.Sleep(50);
                }
                else
                {
                    Console.Write("|| ");
                    Thread.Sleep(50);
                }
            }
        }
        static void Congrats()
        {
            TextPrint("Well done, " + PlayerName + ". You have completed the word.");
            Thread.Sleep(1300);
            TextPrint("Impressive.");
            Thread.Sleep(1000);
            TextPrint("It only took you " + (guessesBegin - guessesRemaining) + " mistakes.");
            Thread.Sleep(800);
            TextPrint("The word was: ");
            Console.WriteLine();

            for (int i = 0; i < wordPicked.Length; i++)
            {
                Console.Write(wordPicked[i].ToString() + ' ');
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
        static void TooBad()
        {
            TextPrint("That's too bad.");
            TextPrint("You could have gotten it.");
            TextPrint("The word was: ");

            for (int i = 0; i < wordPicked.Length; i++)
            {
                TextPrint(wordPicked[i].ToString() + ' ');
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
        static void TextPrint(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(35);
            }
            Console.WriteLine();
        }
        static void Processing()
        {
            for (var i = 0; i < 6; i++)
            {
                Console.WriteLine("|");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("/");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("--");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("\\");
                Thread.Sleep(500);
                Console.Clear();
            }
            Console.Clear();
        }
        /// <summary>
        /// Will require nearly every C# syntax and operation I have learned
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GameHangmen();

        }
    }
}
