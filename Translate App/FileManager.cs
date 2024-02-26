using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using Translate_App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class FileManager
{
    // Method to write content to a file
    public static void WriteFile(string path, string content)
    {
        using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(content); // Writing content to the file
            }
        }
    }

    // Method to overwrite content of a file
    public static void OverriteFile(string path, string content)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(content); // Overwriting content of the file
            }
        }
    }

    // Method to find translation of a word in a file
    public static string findTranslation(string path, int line, string word)
    {
        string[] lines = File.ReadAllLines(path); // Reading all lines from the file
        char value = lines[line + 1][0]; // Getting the first character of the next line
        while (lines[line + 1][0] == value) // Looping until different first character is found
        {
            line++; // Moving to the next line
            string[] splitLine = lines[line].Split(" - "); // Splitting the line by separator
            if (splitLine[0].ToLower() == word.ToLower ()) return splitLine[1]; // Returning translation if word matches
        }
        return "Cannot Translate"; // Returning default message if translation not found
    }
}

class WriteDictionary
{
    // Method to create a new dictionary
    public static Dictionary<char, int> Create()
    {
        return new Dictionary<char, int>(); // Returning a new dictionary
    }

    // Method to sort and write dictionary contents to a file
    public static Dictionary<char, int> SortDictionary(Dictionary<char, int> newDictionary, IEnumerable<IGrouping<char, KeyValuePair<string, string>>> groupByFirstLetter, string filePath)
    {
        int i = 0;
        foreach (var letterGroup in groupByFirstLetter) // Looping through grouped dictionary
        {
            FileManager.WriteFile(filePath, $"{letterGroup.Key}"); // Writing key to file
            newDictionary.Add(letterGroup.Key, i); // Adding key to dictionary
            foreach (var item in letterGroup) // Looping through items in group
            {
                FileManager.WriteFile(filePath, string.Join(" - ", item.Key, item.Value)); // Writing item to file
                i++; 
            }
            i++; 
        }
        return newDictionary; // Returning sorted dictionary
    }

    // Method to add a word to a dictionary and write to a file
    public static void AddWord(string path, IEnumerable<IGrouping<char, KeyValuePair<string, string>>> groupByFirstLetter, Dictionary<char, int> dictionary)
    {
        int i = 0;
        foreach (var letterGroup in groupByFirstLetter) // Looping through grouped dictionary
        {
            FileManager.WriteFile(path, $"{letterGroup.Key}"); // Writing key to file
            dictionary.Add(letterGroup.Key, i); // Adding key to dictionary
            foreach (var item in letterGroup) // Looping through items in group
            {
                FileManager.WriteFile(path, string.Join(" - ", item.Key, item.Value)); // Writing item to file
                i++;    
            }
            i++; 
        }
    }
}
