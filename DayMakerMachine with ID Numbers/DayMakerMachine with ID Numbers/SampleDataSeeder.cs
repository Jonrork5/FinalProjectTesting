using System;
using System.Collections.Generic;
using System.Linq;

namespace DayMakerMachine
{
    public class SampleDataSeeder
    {
        public static void SeedData(WordContext context)
        {
            if (!context.Words.Any())
            {
                // Sample adjectives data
                var adjectives = new List<string>
                {
                    "Beautiful", "Brilliant", "Charming", "Delightful", "Elegant",
                    "Fantastic", "Graceful", "Handsome", "Inspiring", "Joyful",
                    "Kindhearted", "Lovely", "Magnificent", "Noble", "Outstanding",
                    "Passionate", "Radiant", "Stunning", "Talented", "Vibrant"
                };

                // Sample adjective/verbs data
                var adjectiveVerbs = new List<string>
                {
                    "Courageous", "Enchanting", "Fascinating", "Generous", "Harmonious",
                    "Inspiring", "Majestic", "Noble", "Resilient", "Serene",
                    "Achieving", "Creating", "Delighting", "Enriching", "Excelling",
                    "Inspiring", "Mesmerizing", "Radiating", "Uplifting", "Empowering"
                };

                // Sample nouns data
                var nouns = new List<string>
                {
                    "Fella", "Person", "Leader", "Friend", "Companion",
                    "Partner", "Individual", "Soul", "Gem", "Treasure",
                    "Star", "Champion", "Hero", "Darling", "Beauty",
                    "Spirit", "Wonder", "Jewel", "Gemstone", "Sweetheart"
                };

                // Add sample data to the context and save changes
                context.AddRange(adjectives.Select(a => new Word { Text = a, Category = "AdjectivesTable" }));
                context.AddRange(adjectiveVerbs.Select(av => new Word { Text = av, Category = "AdjectiveVerbsTable" }));
                context.AddRange(nouns.Select(n => new Word { Text = n, Category = "NounsTable" }));
                context.SaveChanges();
            }
        }
    }
}