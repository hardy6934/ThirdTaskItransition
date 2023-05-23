using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace ThirdTaskItransition
{
    internal class Program
    {
        public static bool CheckArgs(string[] str)
        {
            if (str.Count() < 3)
            {
                Console.WriteLine("Please enter 3 or more parameters \nFor example - 1 2 3");
                return false;
            }
            else if (str.Count() % 2 == 0)
            {
                Console.WriteLine("please enter an odd count of parameters \nFor example - 1 2 3 or 1 2 3 4 5");
                return false;
            }
            else if (str.GroupBy(x => x).Count() != str.Count())
            {
                 Console.WriteLine("parameters should not be repeated \nFor example - 1 2 3 or 1 2 3 4 5 or 1 2 3 4 5 6 7");
                return false;
            }
            else { return true; }
        }

        static void Main(string[] args)
        { 

            if (CheckArgs(args))
            {
                KeyGeneration keyGeneration = new KeyGeneration();
                HelpTable helpTable = new HelpTable();
                Rules rules = new Rules(args.Count());
                

                bool exit = false;
                while (!exit)
                {
                    Console.Write("\n\n\n\n\n");


                    //вычисление HMACSHA256 ответа
                    string key =keyGeneration.GenerateKey();
                    var compChoise = RandomNumberGenerator.GetInt32(args.Length);
                    Console.WriteLine("HMAC: "+keyGeneration.GenerateHMAC(args[compChoise], key));

                    //вывод возможных ходов
                    Console.WriteLine("Available moves:");
                    for (int i = 0; i < args.Count(); i++)
                    {
                        Console.WriteLine(i + 1 + ". " + args[i]);
                    }
                    Console.WriteLine("0 - exit");
                    Console.WriteLine("? - help");

                    //работа с ответом игрока
                    Console.WriteLine("Please, enter your choise!");
                    var playerChoise =  Console.ReadLine();

                    if (playerChoise == "0")
                    { 
                        exit = true;
                        break;
                    }
                    else if (playerChoise == "?")
                    { 
                        helpTable.Help(args.Count(), args);
                    }

                    int Num;
                    if (!int.TryParse(playerChoise, out Num) || Num <= 0 || Num > args.Length)
                    {
                        Console.Write("\n\n\n\n\n");
                        continue;
                    }


                    Console.WriteLine("Your move: " + args[Num - 1]);
                    Console.WriteLine("Computer move: " + args[compChoise]);


                    if (rules.whoWon(compChoise, Num-1) == "Draw")
                    {
                        Console.WriteLine("Draw");
                    }
                    else if (rules.whoWon(compChoise, Num - 1) == "Win")
                    {
                        Console.WriteLine("Win");
                    }
                    else if (rules.whoWon(compChoise, Num - 1) == "Lose")
                    {
                        Console.WriteLine("Lose");
                    }

                    Console.WriteLine("HMAC key: " + key); 
                }
            }
        }
    }
}


 