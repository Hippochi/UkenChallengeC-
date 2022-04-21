using System;
using System.Collections.Generic;
using System.IO;

namespace LeastFrequentNumber
{
    class Program
    {      
        static void Main(string[] args) //Creates the file path and filenames then passes these through to FileLoader
        {
            string[] filesToLoad = {"5.txt",
            "4.txt",
            "3.txt",
            "2.txt",
            "1.txt"
            };
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))) + "\\files";
            FileLoader(filesToLoad, directory);
            Console.ReadLine();
        }

        static void WriteOutput(string fileName, int mostFrequent, int frequency) // Outputs the string in proper format from the results passed through as parameters
        {
            Console.WriteLine("File: " + fileName + ", Most Frequent Number: "
                + mostFrequent + ", Repeated: " + frequency + " times");
            Console.WriteLine();

        }

        static int[] ArrayFromFile(string filename) //takes a file that uses linebreaks as seperation,
                                                    //turns it into a string array that holds each line in its own string,
                                                    //then creates an array of ints to hold the converted ints from the strings
        { 
            System.IO.StreamReader reader =
                new System.IO.StreamReader(filename);

            string tempString = reader.ReadToEnd().Trim();
            string[] lines = (tempString.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
            reader.Close();

            int[] result = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                result[i] = Int32.Parse(lines[i]);
            }

            
            return result;
        }

        static KeyValuePair<int,int> LeastFrequent(int[] array) //Algorithm to count all of the array elements
        {
            // Hashes all the elements and counts their frequency
            Dictionary<int, int> hashTable =
                        new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                
                int hashKey = array[i];
                if (hashTable.ContainsKey(hashKey))
                {
                    hashTable[hashKey]++;
                }
                else
                    hashTable.Add(hashKey, 1);
                
            }

            //sorts through the hash and compares KVPs to check for lowest frequency
            int max_count = int.MaxValue;
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(0,-1);
            foreach (KeyValuePair<int,int> pair in hashTable)
            {
                if (max_count > pair.Value)
                {
                    max_count = pair.Value;
                    result = pair;
                }
                else if (max_count == pair.Value) // if there's a tie in frequency, chooses the KVP with the lowest value
                {
                    if (result.Key > pair.Key)
                        result = pair;
                }
            }
            Console.WriteLine(result);
            return result;
        }

        static void FileLoader(string[] files, string path) //iterates through each file, calculating the frequency of the elements,
                                                            //then calls upon WriteOutput to put these values into a visible output
        {
            for (int i = 0; i <files.Length;i++)
            {
                KeyValuePair<int, int> KVP = LeastFrequent(ArrayFromFile(path + "\\"+ files[i]));
                WriteOutput(files[i], KVP.Key, KVP.Value);
               
            }
        }
    }
}
