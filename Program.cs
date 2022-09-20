// Adam Di Cioccio
// 041019241
// Lab 01 - .NET Enterprise
// Amir Afrasiabi Rad

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab1 {

    internal class MainClass {

        static Boolean programRunning = true;
        static IList<string> wordList = null;

        public static void Main(string[] args) {
            while(programRunning) {
                printMenu();
                string input = Console.ReadLine();
                
                switch (input) {
                    case "1":
                        importWords();
                        break;
                    case "2":
                        if (!checkIfNull()) {
                            IList<string> wordListCopy = wordList.ToList();
                            Stopwatch stopwatch = Stopwatch.StartNew();
                            stopwatch.Start();
                            iterateAndPrint(BubbleSort(wordListCopy));
                            stopwatch.Stop();
                            TimeSpan ts = stopwatch.Elapsed;
                            string elapsed = String.Format("{0}.{1}", ts.Seconds, ts.Milliseconds / 10);
                            Console.WriteLine("Execution time: " + elapsed + "s");
                        }
                        break;
                    case "3":
                        if (!checkIfNull()) {
                            sortWordsUsingLINQ();
                        }
                        break;
                    case "4":
                        if (!checkIfNull()) {
                            showDistinctWords();
                        }
                        break;
                    case "5":
                        if (!checkIfNull()) {
                            showFirst10Lines();
                        }
                        break;
                    case "6":
                        if (!checkIfNull()) {
                            showStartsWithJ();
                        }
                        break;
                    case "7":
                        if (!checkIfNull()) {
                            showEndsWithD();
                        }
                        break;
                    case "8":
                        if (!checkIfNull()) {
                            showGreaterThan4();
                        }
                        break;
                    case "9":
                        if (!checkIfNull()) {
                            showLessThan3StartsWithA();
                        }
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

        // menu option 1
        public static void importWords() {
            wordList = File.ReadAllLines("/Users/adamdicioccio/Projects/Lab1/Lab1/Words.txt").ToList();
            Console.WriteLine("Successfully uploaded words. The total number of words are " + wordList.Count);
        }

        // menu option 2
        public static IList<string> BubbleSort(IList<string> words){
            int length = words.Count;
            string temp;
            for (int i = 0; i < length - 1; i++) {
                for (int j = i + 1; j < length; j++) {
                    if (words[i].CompareTo(words[j]) > 0) {
                        temp = words[i];
                        words[i] = words[j];
                        words[j] = temp;
                    }
                }
            }
            return words;
        }

        // menu option 3
        public static void sortWordsUsingLINQ() {
            IEnumerable<string> words = (from word in wordList orderby word[0] select word);
            iterateAndPrint(words);
        }

        // menu option 4
        public static void showDistinctWords() {
            IEnumerable<string> words = (from word in wordList.Distinct() select word);
            iterateAndPrint(words);
        }

        // menu option 5
        public static void showFirst10Lines() {
            IEnumerable<string> words = (from word in wordList select word).Take(10);
            iterateAndPrint(words);
        }

        // menu option 6
        public static void showStartsWithJ() {
            IEnumerable<string> words = from word in wordList where word.StartsWith("j") select word;
            iterateAndPrint(words);
        }

        // menu option 7
        public static void showEndsWithD() {
            IEnumerable<string> words = from word in wordList where word.EndsWith("d") select word;
            iterateAndPrint(words);
        }

        // menu option 8
        public static void showGreaterThan4() {
            IEnumerable<string> words = from word in wordList where word.Length > 4 select word;
            iterateAndPrint(words);
        }

        // menu option 9
        public static void showLessThan3StartsWithA() {
            IEnumerable<string> words = from word in wordList where word.Length < 3 && word.StartsWith("a") select word;
            iterateAndPrint(words);
        }

        // iterates through IEnumerable<string> that is passed into it, prints output
        public static void iterateAndPrint(IEnumerable<string> words) {
            int count = 0;
            foreach (string word in words) {
                Console.Write(word + " ");
                count++;
            }
            Console.WriteLine("\nTotal words: " + count);
        }

        // checks if user initalized list, returns true if list is empty
        public static Boolean checkIfNull() {
            if (wordList == null) {
                Console.WriteLine("Please upload words in 'Words.txt' before continuing...");
                return true;
            }
            return false;
        }

        // void function that displays menu system
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
