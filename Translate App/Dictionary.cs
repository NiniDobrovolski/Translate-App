using System;
namespace Translate_App
{
    // Class containing static methods to create dictionaries for translation
    public class DictionaryTypes
	{
        // Method to add a word and its meaning to a dictionary
        public static void Add(string word, string meaning, Dictionary<string, string> DictionaryType)
        {
            DictionaryType.Add(word, meaning);
        }

        // Creating and returning a new English to Georgian dictionary
        public static Dictionary <string,string > CreateENG_GEODictionary()
		{
            // Initializing dictionary with English words and their Georgian translations
            return new Dictionary<string, string>()
            {
                {"Hello","გამარჯობა" },
                {"Goodbye", "ნახვამდის"},
                {"Thank you", "მადლობა"},
                {"Yes", "დიახ"},
                {"No", "არა"},
                {"Please", "გთხოვთ"},
                {"Sorry", "ბოდიში"},
                {"Excuse me", "უკაცრავად"},
                {"Friend", "მეგობარი"},
                {"Family", "ოჯახი"},
                {"Love", "სიყვარული"},
                {"Food", "საკვები"},
                {"Water", "წყალი"},
                {"Mountain", "მთა"},
                {"Sun", "მზე"},
                {"Moon", "მთვარე"},
                {"Sky", "ცა"},
                {"Rain", "წვიმა"},
                {"Fire", "ცეცხლი"},
                {"Book", "წიგნი"},
                {"Music", "მუსიკა"}

            };
        }

        // Creating and returning a new Georgian to English dictionary
        public static Dictionary<string, string> CreateGEO_ENGDictionary()
        {
            // Initializing dictionary with Georgian words and their English translations
            return new Dictionary<string, string>()
            {
                {"გამარჯობა", "Hello"},
                {"ნახვამდის", "Goodbye"},
                {"მადლობა", "Thank you"},
                {"დიახ", "Yes"},
                {"არა", "No"},
                {"გთხოვთ", "Please"},
                {"ბოდიში", "Sorry"},
                {"უკაცრავად", "Excuse me"},
                {"მეგობარი", "Friend"},
                {"ოჯახი", "Family"},
                {"სიყვარული", "Love"},
                {"საკვები", "Food"},
                {"წყალი", "Water"},
                {"მთა", "Mountain"},
                {"მზე", "Sun"},
                {"მთვარე", "Moon"},
                {"ცა", "Sky"},
                {"წვიმა", "Rain"},
                {"ცეცხლი", "Fire"},
                {"წიგნი", "Book"},
                {"მუსიკა", "Music"}


            };
        }

        // Method to create Chinese to English dictionary
        public static Dictionary<string, string> CreateCHI_ENGDictionary()
        {
            // Initializing dictionary with Chinese words and their English translations
            return new Dictionary<string, string>()
                { 
                { "你好", "Hello"},
                { "再见", "Goodbye"},
                { "谢谢", "Thank you"},
                { "是的", "Yes"},
                { "不", "No"},
                { "请", "Please"},
                { "对不起", "Sorry"},
                { "打扰了", "Excuse me"},
                { "朋友", "Friend"},
                { "家人", "Family"},
                { "爱", "Love"},
                { "食物", "Food"},
                { "水", "Water"},
                { "山", "Mountain"},
                { "太阳", "Sun"},
                { "月亮", "Moon"},
                { "天空", "Sky"},
                { "雨", "Rain"},
                { "火", "Fire"},
                { "书", "Book"},
                { "音乐", "Music"}
                };
                
        }

        // Method to create English to Chinese dictionary
        public static Dictionary<string, string> CreateENG_CHIDictionary()
        {
            // Initializing dictionary with English words and their Chinese translations
            return new Dictionary<string, string>()
            {   { "Hello", "你好"},
                { "Goodbye", "再见"},
                { "Thank you", "谢谢"},
                { "Yes", "是的"},
                { "No", "不"},
                { "Please", "请"},
                { "Sorry", "对不起"},
                { "Excuse me", "打扰了"},
                { "Friend", "朋友"},
                { "Family", "家人"},
                { "Love", "爱"},
                { "Food", "食物"},
                { "Water", "水"},
                { "Mountain", "山"},
                { "Sun", "太阳"},
                { "Moon", "月亮"},
                { "Sky", "天空"},
                { "Rain", "雨"},
                { "Fire", "火"},
                { "Book", "书"},
                { "Music", "音乐"}

            };
        }
        // Method to create a null dictionary (used for initialization)
        public static Dictionary<string, string> CreateENullDictionary()
        {

            return null;
        }

    }
}

