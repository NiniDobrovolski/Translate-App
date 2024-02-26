using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Translate_App;



bool k = true; // Variable to control the outer loop
bool t = true; // Variable to control the inner loop
string request = null; // Variable to store user's translation request
Dictionary<string, string> words = DictionaryTypes.CreateENullDictionary(); // Dictionary to store words and their translations
Dictionary<char, int> sortedDictionary = null; // Dictionary to store sorted words

// Outer loop to control the translation process
while (k)
{
    k = false; // Setting k to false initially

    string lang1 = null, lang2 = null; // Variables to store chosen languages

    // Inner loop to handle language selection
    while (t == true)
    {
        Console.Write("Please Choose Languages:\n\tAvailable languages: ENG GEO CHI\n\tTranslate from: ");
        lang1 = Console.ReadLine(); 

        try
        {
            if (lang1 != "ENG" && lang1 != "GEO" && lang1 != "CHI")
            {
                t = true; // Keeping the inner loop running if language is not valid
                throw new LangReqExption(); // Throwing exception for invalid language
            }
            else
            {
                t = false; // Exiting the inner loop if language is valid
            }
        }
        catch (LangReqExption ex)
        {
            Console.WriteLine(ex.Message); // Handling the exception and displaying error message
        }
    }

    // Resetting the inner loop condition
    while (t == false)
    {
        Console.Write("\tAvailable languages: ENG GEO CHI\n\tto: ");
        lang2 = Console.ReadLine(); 

        try
        {
            if (lang2 != "ENG" && lang2 != "GEO" && lang2 != "CHI")
            {
                t = false; // Keeping the inner loop running if language is not valid
                throw new LangReqExption(); // Throwing exception for invalid language
            }
            else
            {
                t = true; // Exiting the inner loop if language is valid
            }
        }
        catch (LangReqExption ex)
        {
            Console.WriteLine(ex.Message); // Displaying error message
        }
    }

    try
    {
        if (lang1 == lang2)
        {
            throw new Translate_App.ArgumentNullException(); // Throwing exception if both languages are the same
        }
        else
        {
            // Choosing the appropriate dictionary based on selected languages
            if (lang1 == "ENG" && lang2 == "GEO") { words = DictionaryTypes.CreateENG_GEODictionary(); }
            else if (lang1 == "ENG" && lang2 == "CHI") { words = DictionaryTypes.CreateENG_CHIDictionary(); }
            else if (lang1 == "GEO" && lang2 == "ENG") { words = DictionaryTypes.CreateGEO_ENGDictionary(); }
            else if (lang1 == "CHI" && lang2 == "ENG") { words = DictionaryTypes.CreateCHI_ENGDictionary(); }

            // Grouping words by first letter
            IEnumerable<IGrouping<char, KeyValuePair<string, string>>> groupByFirstLetter =
               (IEnumerable<IGrouping<char, KeyValuePair<string, string>>>)(from word in words
                                                                            orderby word.Key[0]
                                                                            group word by word.Key[0]);

            // Setting up file paths and directories
            string mainDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"Translator";
            DirectoryInfo mainCat = new DirectoryInfo(mainDir);
            mainCat.Create();
            string filePath = mainCat + @$"\{lang1}-{lang2}.txt";

            try
            {
                // Sorting the dictionary and writing to file
                sortedDictionary = WriteDictionary.SortDictionary(WriteDictionary.Create(), groupByFirstLetter, filePath);

                // Getting user's translation request
                Console.Write("Enter The Word You Want To Translate:  ");
                request = Console.ReadLine();

                // Finding translation from file
                string line = FileManager.findTranslation(filePath, sortedDictionary[request[0]], request);
                if (line != "Cannot Translate") { Console.WriteLine($"\rTranslation:  " + line); }
                else throw new KeyNotFoundException(); // Throwing exception if translation not found

                FileManager.OverriteFile(filePath, null); // Overwriting file contents
            }
            catch (KeyNotFoundException)
            {
                // Handling translation not found
                Console.WriteLine("Translation Not Found! If You Would Like To Add Given Word To The Dictionary, Write 'add'");
                string ans = Console.ReadLine();
                if (ans == "add")
                {
                    // Adding new word to dictionary
                    Console.WriteLine($"Enter The Meaning Of {request}: ");
                    string meaning = Console.ReadLine();

                    words.Add(request, meaning);
                    groupByFirstLetter = (IEnumerable<IGrouping<char, KeyValuePair<string, string>>>)(from word in words
                                                                                                      orderby word.Key[0]
                                                                                                      group word by word.Key[0]);
                    sortedDictionary = WriteDictionary.SortDictionary(WriteDictionary.Create(), groupByFirstLetter, filePath);
                    WriteDictionary.AddWord(filePath, groupByFirstLetter, sortedDictionary);
                }
                else { k = false; } // Exiting outer loop if user chooses not to add word
            }
           
        }
    }
    catch (Translate_App.ArgumentNullException ex)
    {
        // Handling exception if both languages are the same
        Console.WriteLine(ex.Message);
        k = true; // Setting k to true to continue outer loop
    }
}
