using System;
using System.Collections.Generic;

namespace LeastFrequentNumber
{
    class Program
    {      
        static void Main(string[] args)
        {
            string[] filesToLoad = {"5.txt",
            "4.txt",
            "3.txt",
            "2.txt",
            "1.txt"
            };
            FileLoader(filesToLoad, "H:/SelfProjects/UkenChallenge/UkenChallenge/LeastFrequentNumber/Files");
            Console.ReadLine();
        }

        static void WriteOutput(string fileName, int mostFrequent, int frequency)
        {
            Console.WriteLine("File: " + fileName + ", Most Frequent Number: "
                + mostFrequent + ", Repeated: " + frequency + " times");
            Console.WriteLine();

        }

        static int[] ArrayFromFile(string filename)
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

        static KeyValuePair<int,int> LeastFrequent(int[] array)
        {
            // Insert all elements in hash
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

            // find max frequency.
            int max_count = int.MaxValue;
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(0,-1);
            foreach (KeyValuePair<int,int> pair in hashTable)
            {
                if (max_count > pair.Value)
                {
                    max_count = pair.Value;
                    result = pair;
                }
                else if (max_count == pair.Value)
                {
                    if (result.Key > pair.Key)
                        result = pair;
                }
            }
            Console.WriteLine(result);
            return result;
        }

        static void FileLoader(string[] files, string path)
        {
            for (int i = 0; i <files.Length;i++)
            {
                KeyValuePair<int, int> KVP = LeastFrequent(ArrayFromFile(path + "/"+ files[i]));
                WriteOutput(files[i], KVP.Key, KVP.Value);
               
            }
        }
    }
}
