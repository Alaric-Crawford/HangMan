using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        /// <summary>
        /// Will require nearly every C# syntax and operation I have learned
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Ask for the players' name
            Console.WriteLine("Welcome. What is your name?");
            string name = Console.ReadLine();
            //Ask player to pick a category
            Console.Write("Okay " + name + ", ");
            //create variable for while loop
            var go = true;
            while (go == true)
            {
                Console.Write("what category do you want: ");
                Console.WriteLine(" Animal, Plant, or Other?");
                string choice = Console.ReadLine();
                choice = choice.ToLower();

                //Run function according to choice
                if (choice == "animal")
                {
                    HangMan1(name);
                }
                if (choice == "plant")
                {
                    HangMan2(name);
                }
                if (choice == "other")
                {
                    HangMan3(name);
                }

            }

            Console.ReadKey();
        }
        //make HangMan function(s)
        static void HangMan1(string name)
        {
            Console.WriteLine("Alrighty then, " + name + ", this won't be easy!");
            Console.WriteLine("Please only guess one letter at a time unless you are guessing the word.");
            //Make list containing possible words for computer to pick
            List<string> animalList = new List<string>();
            animalList.Add("lion");
            animalList.Add("duck");
            animalList.Add("cow");
            animalList.Add("horse");
            animalList.Add("moose");
            animalList.Add("dikdik");
            animalList.Add("mongoose");
            //Set the number of items within the list to a variable
            var choices = animalList.Count();
            //Create variable and set it to true
            var play = true;
            //Macro 'while' loop start
            while (play == true)
            {
                //Make random class
                var deciding = new Random();
                var wordGot = deciding.Next(0, choices);
                //storing the word picked and finding its' length
                string chosenWord = animalList[wordGot];
                int spaces = chosenWord.Length;
                //make string variable to represent the word without showing the actual word
                string hidden = "";
                //create variables to store and track guesses
                int guesses = spaces + 4;
                int guessesLeft = guesses;
                //variable for tracking what letters have been guessed
                string letters = "";
                //'for' loop that creates sections according to the "hidden" string variable
                for (var i = 0; i < spaces; i++)
                {
                    hidden += "_ ";
                }
                var tracking = hidden.Split(' ');
                //Inform the player the word has been picked
                Console.WriteLine("I have the word. Good luck, mein froi!");
                var word = true;
                while (word == true)
                {
                    //print hidden word placeholder
                    Console.WriteLine(hidden);
                    //tell the player what they have guessed and how many guesses they have left
                    Console.WriteLine("Letters Guessed: " + letters);
                    Console.WriteLine("Guesses Remaining: " + guessesLeft);
                    //log the players' guesses
                    string playerGuess = Console.ReadLine();
                    playerGuess = playerGuess.ToLower();
                    int pGL = playerGuess.Length;
                    //check how long the players' guess is
                    if (pGL > 1)
                    {
                        if (playerGuess == chosenWord)
                        {
                            play = false;
                            Console.WriteLine("Well done. You had " + guessesLeft + ". Try to do it in fewer guesses next time!");
                        }
                        else
                        {
                            guessesLeft -= 1;
                        }
                    }
                    else
                    {
                        var success = false;
                        letters += playerGuess;
                        for (var i = 0; i < spaces; i++)
                        {
                            string recheck = chosenWord[i].ToString();
                            if (playerGuess == recheck)
                            {
                                success = true;
                            }
                        }
                        if (success)
                        {

                        }
                        else
                        {
                            guessesLeft -= 1;
                        }
                    }
                    if (guessesLeft == 0)
                    {
                        Console.WriteLine("YOU HAVE RUN OUT OF GUESSES.");
                        Console.WriteLine("YOU LOSE!");
                        play = false;
                    }
                }
            }
        }
        static void HangMan2(string name)
        {
        }
        static void HangMan3(string name)
        {
        }
    }
}
