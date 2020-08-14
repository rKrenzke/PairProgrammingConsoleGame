using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingConsoleGame
{
    public class WordGame
    {

        public void TitleScreen()
        {
            string s = "THE BRUTE ON THE BRIDGE";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            string underline = "-------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - underline.Length) / 2, Console.CursorTop);
            Console.WriteLine(underline);

            string txt = "Press Any Button To start";
            int count = 0;
            while (count < 4)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
                count++;
            }
            WriteBlinkingText(txt, 500, true);
            Console.WriteLine();
            Console.ReadKey();
            RunAgeGate();
        }

        private void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
            {
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
                Console.Write(text);
            }
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);
        }
        private void RunAgeGate()

        {
            Console.Clear();
            Player newPlayer = new Player();
            int count = 0;
            while (true)
            {
                if (count > 0)
                {
                    Console.WriteLine("Something went wrong, try typing that again");
                }
                Console.WriteLine("What is your birthdate? (YYYY/MM/DD)");
                string input = Console.ReadLine();
                if (input.Length == 10)
                {
                    if (input[4] == '/' && input[7] == '/')
                    {

                        newPlayer.PlayerBirthDate = Convert.ToDateTime(input);
                        if (newPlayer.Age >= 18 && newPlayer.Age <= 60)
                        {
                            Console.WriteLine("Enjoy the adventure!");
                            Console.WriteLine("Press any key to begin");
                            Console.ReadKey();
                            Start();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, this game contains text descriptions of mild violence and is not suitable for all ages.");
                            Console.WriteLine("Press any key to exit");
                            Console.ReadKey();
                            return;
                        }
                    }
                    else
                    {
                        count++;
                        Console.Clear();
                    }
                }
                else
                {
                    count++;
                    Console.Clear();
                }

            }
        }
        private void Start()
        {
            Console.Clear();
            FlavorText();
            string[] arr = GetDifficulty();
            RunGame(arr);
            PlayAgain();
        }

        private string[] GetDifficulty()
        {
            string[] arr;
            Console.WriteLine("How scared are you of this brute? ");
            Console.WriteLine("1. Terrified");
            Console.WriteLine("2. He might be smarter than he looks");
            Console.WriteLine("3. Psh, I've seen squirrels more frightening than him.");
            string userDiff = Console.ReadLine();
            switch (userDiff)
            {
                case "1":
                    Console.WriteLine("Difficulty set to: Easy");
                    arr = EasyArray();
                    return arr;
                case "2":
                    Console.WriteLine("Difficulty set to: Medium");
                    arr = MediumArray();
                    return arr;
                case "3":
                    Console.WriteLine("Difficulty set to: Hard");
                    arr = HardArray();
                    return arr;
                case "1.":
                    Console.WriteLine("Difficulty set to: Easy");
                    arr = EasyArray();
                    return arr;
                case "2.":
                    Console.WriteLine("Difficulty set to: Medium");
                    arr = MediumArray();
                    return arr;
                case "3.":
                    Console.WriteLine("Difficulty set to: Hard");
                    arr = HardArray();
                    return arr;
                default:
                    Console.WriteLine("Well since you couldn't enter a number between 1 and 3, I'm going to guess Easy is the right difficulty");
                    arr = EasyArray();
                    return arr;
            }
        }

        private void FlavorText()
        {
            Console.WriteLine();
            Console.WriteLine(
                "It's getting dark and you need to get back to the village before nightfall,\n" +
                "but some brute has set himself up as a gatekeeper at the only bridge over the river.\n" +
                "He didn't find anything of value in your pockets and so demands you play his little guessing\n" +
                "game to pass.  He has also promised violence for each incorrect guess.\n" + "\n" +
                "'Guess my secret word, peasant!' He roars. Yikes, he sounds angry. Good luck!");
            Console.WriteLine();
        }
        private string[] EasyArray()
        {
            string[] listOfWords = new string[] { "apple", "guitar", "house", "laptop", "computer", "mouse", "phone", "grape", "poptart", "shirt" };
            return listOfWords;
        }
        private string[] MediumArray()
        {
            string[] listOfWords = new string[] { "revolution", "adventure", "guitar", "purse", "laptop", "computer", "mouse", "phone", "elevenfiftyacademy", "headphones", "poptarts", "sweater" };
            return listOfWords;
        }
        private string[] HardArray()
        {
            string[] listOfWords = new string[] { "queue", "revolution", "unpleasent", "discouraged", "resourcefulness", "miraculous", "disorganized", "unfortunately", "complex", "proportion", "euphrates", "lexicon", "inattentive", "cacophony", "elevenfiftyacademy" };
            return listOfWords;
        }

        private void YouAreDead()
        {
            Console.Clear();
            Console.WriteLine("You Are Dead.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(
                "            ____               \n" +
                "           |    |\n" +
                "           |    |\n" +
                "      _____|    |_____\n" +
                "     |                |\n" +
                "     |_____      _____|\n" +
                "           |    |\n" +
                "           |    |\n" +
                "           |    |\n" +
                "           |    |\n" +
                "         __|____|__\n" +
                "       _/          \\_   _\n" +
                "    __/              \\_/ \\   \n" +
                "___/                      \\__");
            Console.WriteLine();
            Console.WriteLine(
                "The brute has lost patience for this game.\n" +
                "You're wrong guesses and his ogre strength\n" +
                "are too much for either of you to bear any longer.\n");

        }
        private void RunGame(string[] Arr)
        {

            Random rnd = new Random();
            int rand = rnd.Next(Arr.Length);
            string secretWord = Arr[rand];
            int health = 7;
            int wordLetters = secretWord.Length;


            Console.Write("Guess the secret word: ");
            for (int i = 0; i < wordLetters; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

            bool isCorrectWord = false;
            string userGuess = Console.ReadLine();
            int guessLetters = userGuess.Length;
            while (true)
            {
                userGuess = userGuess.ToLower();
                if (userGuess == secretWord)
                {
                    isCorrectWord = true;
                    break;
                }
                int diff = secretWord.Length - userGuess.Length;
                if (diff >= 0)
                {
                    for (int x = 0; x <= diff; x++)
                    {
                        userGuess += " ";
                    }
                }

                for (int i = 0; i < wordLetters; i++)
                {

                    if (userGuess[i] == secretWord[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(userGuess[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                    }

                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                switch (health)
                {
                    case 7:
                        Console.Write("The brute gives you a solid punch in the gut. He considers this a merciful reaction.\n" +
                            " Health remaining:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("6");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 6:
                        Console.Write("Two fingers from his massive right hand sally forth directly into your eyes.\n" +
                            "At least you don't need to see to guess.\n" +
                            " Health remaining: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("5");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        Console.Write("You used to be an adventurer like me, until a big brute smashed your kneecaps.\n" +
                            " Health remaining: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("4");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        Console.Write("I don't know if you're just a masochist or are not great at word play.\n" +
                            "Don't forget to pick up those teeth he just knocked out if you make it out of this mess.\n" +
                            " Health remaining:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("3");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        Console.Write("I had no idea someone could use a walking stick with such force. He sure is strong!\n" +
                            "Sorry about your ankles, though...\n" +
                            " Health remaining: ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("2");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        Console.Write("You just got rocked. Literally. A rock in this brute's hand is like Mjolnir in Thor's!\n" +
                            "Health remaning: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("1");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 1:
                        break;
                }


                health--;
                if (health == 0)
                {
                    break;
                }
                userGuess = Console.ReadLine();
            }
            if (isCorrectWord == true && health == 7)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Incredible! You are suspiciously lucky and the brute is furious. Better run home before he changes his mind.");
            }
            else if (isCorrectWord == true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You did it! Now get on home and get some bandages on those grievous wounds!");
            }
            else
            {
                YouAreDead();
                Console.WriteLine($"The SECRET WORD was: {secretWord}");
            }

            Console.WriteLine();
        }
        private void PlayAgain()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to try again? (Y/N)");
            string again = Console.ReadLine();
            again = again.ToLower();
            if (again == "y" || again == "yes" || again == "yup" || again == "ye" || again == "yes sir" || again == "yes " || again == "yepp")
            {
                Start();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing, peasant!");
            }
            Console.ReadLine();
        }

    }
}
