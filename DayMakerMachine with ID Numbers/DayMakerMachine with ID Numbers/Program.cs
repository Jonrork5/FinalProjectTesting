using System;

namespace DayMakerMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init(); // Initialize SQLitePCL

            Console.WriteLine("Hello! Welcome to the Day Maker Machine! A.K.A Compliment Slots!");
            Console.WriteLine("Please type SPIN and hit enter to get a boost of self-confidence!");

            string userInput = Console.ReadLine();

            if (userInput.ToUpper() == "SPIN")
            {
                // Call a method to generate and display the compliment
                GenerateAndDisplayCompliment();
            }
            else
            {
                Console.WriteLine("Invalid input. Please type SPIN and hit enter.");
                LogEvent("Invalid input received: " + userInput);
            }
        }

        static void GenerateAndDisplayCompliment()
        {
            // Fetch random words' IDs from each table
            int adjectiveId = GetRandomWordIdFromTable("AdjectivesTable");
            int adjectiveVerbId = GetRandomWordIdFromTable("AdjectiveVerbsTable");
            int nounId = GetRandomWordIdFromTable("NounsTable");

            // Fetch random words based on their IDs
            string adjective = FetchWordById("AdjectivesTable", adjectiveId);
            string adjectiveVerb = FetchWordById("AdjectiveVerbsTable", adjectiveVerbId);
            string noun = FetchWordById("NounsTable", nounId);

            // Generate a random compliment
            string compliment = $"{adjective} {adjectiveVerb} {noun}";

            // Display the compliment
            Console.WriteLine("Your compliment for today is: " + compliment);

            // Log the event
            LogEvent("Compliment generated: " + compliment);
        }

        static int GetRandomWordIdFromTable(string tableName)
        {
            using (var context = new WordContext())
            {
                var words = context.Words.Where(w => w.Category == tableName).Select(w => w.Id).ToList();
                int randomIndex = new Random().Next(words.Count);
                return words[randomIndex];
            }
        }

        static string FetchWordById(string tableName, int id)
        {
            using (var context = new WordContext())
            {
                var word = context.Words.FirstOrDefault(w => w.Category == tableName && w.Id == id);
                return word != null ? word.Text : null;
            }
        }

        static void LogEvent(string message)
        {
            string logFilePath = "log.txt";
            try
            {
                using (System.IO.StreamWriter writer = System.IO.File.AppendText(logFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }
    }
}
