using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Lab1 {

    internal class MainClass {

        static Boolean programRunning = true;
        static IList<string> allLinesText = null;

        public static void Main(string[] args) {
            while(programRunning) {
                printMenu();

                string input = Console.ReadLine();
                
                switch (input) {
                    case "1":
                        importWords();
                        break;
                    case "2":
                        Console.WriteLine("Selected option 2");
                        break;
                    case "3":
                        Console.WriteLine("Selected option 3");
                        break;
                    case "4":
                        Console.WriteLine("Selected option 4");
                        break;
                    case "5":
                        if (!checkIfNull()) {
                            showFirst10Lines();
                        }
                        break;
                    case "6":
                        Console.WriteLine("Selected option 6");
                        break;
                    case "7":
                        Console.WriteLine("Selected option 7");
                        break;
                    case "8":
                        Console.WriteLine("Selected option 8");
                        break;
                    case "9":
                        Console.WriteLine("Selected option 9");
                        break;
                    case "x":
                        Console.WriteLine("Quitting program...");
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;

                }
                
            }
            


        }

        public static void importWords() {
            IList<string> temp = File.ReadAllLines("/Users/adamdicioccio/Projects/Lab1/Lab1/Words.txt").ToList();
            allLinesText = temp;
            Console.WriteLine("Successfully uploaded words. The total number of words are " + allLinesText.Count);
        }

        public static void showFirst10Lines() {
            if (allLinesText == null) {
                Console.WriteLine("Please upload words in 'Words.txt' before continuing...");
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine(allLinesText[i]);
            }
        }

        public static Boolean checkIfNull() {
            if (allLinesText == null) {
                Console.WriteLine("Please upload words in 'Words.txt' before continuing...");
                return true;
            } else {
                return false;
            }
        }

        public static void printMenu() {
            Console.WriteLine("-----------\nPlease enter one of the following options\n" +
                "1 - Import Words from File\n" +
                "2 - Bubble Sort words\n" +
                "3 - LINQ / Lambda sort words\n" +
                "4 - Count the Distinct Words\n" +
                "5 - Take the first 10 words\n" +
                "6 - Get and display words that start with 'j' and display the count\n" +
                "7 - Get and display words that end with 'd' and display the count\n" +
                "8 - Get and display words that are greater than 4 characters long, and display the count\n" +
                "9 - Get and display words that are less than 3 characters long and start with the letter 'a', and display the count\n" +
                "x – Exit\n-----------");
        }
    }
}
