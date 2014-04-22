﻿using System;
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
        static string[] WordsAvailable = { "guava", "godzilla", "lion", "pigeon", "plantain", "jabberwocky", "vorpal", "nightmare", "basilisk" };
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


            FigureOutWord();
            Console.Clear();

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
        }
        static void WouldYouLikeToPlay()
        {
            TextPrint("Hello. Would you like to play a game?");
            Thread.Sleep(1500);
            Console.Clear();
            TextPrint("I require your name.");

            PlayerName = Console.ReadLine().ToString();

            Console.Clear();

            TextPrint("Very well, " + PlayerName + ".");
            Thread.Sleep(160);
            TextPrint("I shall begin.");
            Thread.Sleep(160);
            TextPrint("I will decide upon a word.");
            Thread.Sleep(160);
            TextPrint("You will have to guess what it is.");
            Thread.Sleep(160);
            TextPrint("If you guess wrong, you will lose a guess.");
            Thread.Sleep(160);
            TextPrint("If your guesses run down to zero, you lose.");
            Thread.Sleep(160);
            TextPrint("Any letter within the word you guess will appear in place of a spacer.");
            Thread.Sleep(160);
            TextPrint("I hope you are ready, " + PlayerName + ", because these words aren't easy.");
            Thread.Sleep(160);
            TextPrint("Press any key to continue...if you dare.");
            Console.ReadKey();
        }
        static void FigureOutWord()
        {
            Random noPattern = new Random();

            int patternIndex = noPattern.Next(0, WordsAvailable.Length);

            wordPicked = WordsAvailable[patternIndex].ToUpper();

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
            }
            ReviewAndAnalyze();
        }
        static void ReviewAndAnalyze()
        {
            Console.WriteLine();
            TextPrint("Enter your guess");

            playerGuess = Console.ReadLine().ToUpper();
            Console.Clear();

            if (playerGuess.Length > 1)
            {
                if (playerGuess == wordPicked)
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
                }
                else
                {
                    Console.Write("|| ");
                }
            }
        }
        static void Congrats()
        {
            TextPrint("Well done, " + PlayerName + ". You have completed the word.");
            TextPrint("Impressive.");
            TextPrint("It only took you " + (guessesBegin - guessesRemaining) + " mistakes.");

            TextPrint("The word was: ");
            Console.WriteLine();

            for (int i = 0; i < wordPicked.Length; i++)
            {
                Console.Write(wordPicked[i].ToString() + ' ');
            }

            Console.WriteLine();
            Console.WriteLine();

            TextPrint("END OF LINE.");
        }
        static void TooBad()
        {
            TextPrint("That's too bad.");
            TextPrint("You could have gotten it.");
            TextPrint("The word was: ");

            for (int i = 0; i < wordPicked.Length; i++)
            {
                TextPrint(wordPicked[i].ToString() + ' ');
            }
            Console.WriteLine();

            TextPrint("If you feel gutsy, you may try again later.");
            TextPrint("END OF LINE.");
        }
        static void TextPrint(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Will require nearly every C# syntax and operation I have learned
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GameHangmen();

            Console.ReadKey();
        }
    }
}
