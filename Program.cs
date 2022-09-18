using System;
using System.Linq;
using System.IO;

namespace Lab1 {

    internal class MainClass {

        static Boolean programRunning = true;

        public static void Main(string[] args) {
            while(programRunning) {
                printMenu();

                string input = Console.ReadLine();
                Console.WriteLine("Input = " + input);

                switch(input) {
                    case "1":
                        Console.WriteLine("Selected option 1");
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
                        Console.WriteLine("Selected option 5");
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
