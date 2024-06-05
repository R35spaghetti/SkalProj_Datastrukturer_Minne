﻿using System;
using System.Text.RegularExpressions;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine(
                    "Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            List<string> arbitraryList = new List<string>();
            string input;
            do
            {
                Console.WriteLine("Enter +yourTerm to add a value to the list" +
                                  "enter -yourTerm to remove it, type x to exit.");
                input = Console.ReadLine().TrimEnd();
                if (string.IsNullOrEmpty(input) || !char.TryParse(input[0].ToString(), out var operation)) continue;
                string value = input[1..];

                switch (operation)
                {
                    case '+':
                        arbitraryList.Add(value);
                        Console.WriteLine($"Added '{value}' to the list.");
                        break;
                    case '-':
                        Console.WriteLine(arbitraryList.Remove(value)
                            ? $"Removed '{value}' from the list."
                            : $"'{value}' was not found in the list.");
                        break;
                    default:
                        Console.WriteLine("Please use only + or -.");
                        break;
                }

                Console.WriteLine($"List size: {arbitraryList.Count}, Capacity: {arbitraryList.Capacity}");
            } while (input.ToLower() != "x");

            Console.WriteLine("Going back to the main menu...");
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
             */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> examinedQueue = new Queue<string>();
            string input;

            do
            {
                Console.WriteLine("Make your choice by entering the corresponding number:" +
                                  "\n 1. Add item to the queue" +
                                  "\n 2. Remove item from the queue" +
                                  "\n 3. Return to menu");
                input = Console.ReadLine()?.TrimEnd() ?? string.Empty;
                string value;
                switch (input)
                {
                    case "1":
                        Console.Write("Enter something to add: ");
                        value = Console.ReadLine() ?? string.Empty;
                        examinedQueue.Enqueue(value);
                        Console.WriteLine($"Added {value}");
                        DisplayValues(examinedQueue);
                        break;
                    case "2":
                        if (examinedQueue.Count > 0)
                        {
                            value = examinedQueue.Dequeue();
                            Console.WriteLine($"Removed {value}");
                            DisplayValues(examinedQueue);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty!\n");
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid input, try again");
                        break;
                }
            } while (input != "3");

            Console.WriteLine("Returning to menu...");
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
             */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> examinedStack = new Stack<string>();
            string input;

            do
            {
                Console.WriteLine("Make your choice by entering the corresponding number:" +
                                  "\n 1. Add item to the stack" +
                                  "\n 2. Remove item from the stack" +
                                  "\n 3. Return to menu");
                input = Console.ReadLine()?.TrimEnd() ?? string.Empty;
                string value;
                switch (input)
                {
                    case "1":
                        Console.Write("Enter something to add: ");
                        value = Console.ReadLine() ?? string.Empty;
                        examinedStack.Push(value);
                        Console.WriteLine($"Added {value}");
                        DisplayValues(examinedStack);
                        break;
                    case "2":
                        if (examinedStack.Count > 0)
                        {
                            value = examinedStack.Pop();
                            Console.WriteLine($"Removed {value}");
                            DisplayValues(examinedStack);
                        }
                        else
                        {
                            Console.WriteLine("Stack is empty!");
                        }

                        break;
                }
            } while (input != "3");
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
             */
        }

        static void CheckParanthesis()
        {
            var parenthesisStack = new Stack<char>();
            bool correctParanthesis = true; 
            string input;
            do
            {
                Console.WriteLine("Check if your input has the correct brackets");
                Console.WriteLine("Example of correct: (()), {}, [({})]\n" +
                                  "Example of incorrect: (()])," +
                                  "\nEnter only x to return to the main menu");
                do
                {
                    input = Console.ReadLine()?.TrimEnd() ?? string.Empty;
                    if (IsStringValid(input)) ;
                    {
                        Console.WriteLine("Incorrect input, try again.");
                    }
                } while (IsStringValid(input));

                foreach (var c in input)
                {
                    switch (c)
                    {
                        case '(':
                        case '[':
                        case '{':
                            parenthesisStack.Push(c);
                            break;

                        case ')':
                        case ']':
                        case '}':
                            
                            if (parenthesisStack.Count == 0 || !MatchingBrackets(parenthesisStack.Pop(), c))
                            {
                                correctParanthesis = false;
                            }
                            else
                            {
                                correctParanthesis = true;
                            }

                            break;
                        default:
                            continue;
                    }
                }

              
                Console.WriteLine($"input is {(correctParanthesis)}");
            } while (input != "x");

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
        }

        static bool MatchingBrackets(char openingBracket, char closingBracket)
        {
            return openingBracket == '(' && closingBracket == ')' ||
                   openingBracket == '[' && closingBracket == ']' ||
                   openingBracket == '{' && closingBracket == '}';
        }

        static bool IsStringValid(string input)
        {
            Match match = Regex.Match(input, @"^\s*(\)|\]|}|\s)");
            if (match.Success)
            {
                return true;
            }

            return false;

        }
        static void DisplayValues<T>(IEnumerable<T> collection)
        {
            Console.WriteLine($"{collection.GetType()} contains the following:");
            foreach (var item in collection)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("");
        }
    }
}