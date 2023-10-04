using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext
{
    public class RandomDataGenerator
    {
        private readonly Random _random = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public string RandomCity()
        {
            List<string> cities = new List<string>
            {
                "Stockholm", "Gothenburg", "Malmö", "Uppsala", "Västerås", "Örebro", "Linköping", "Helsingborg", "Norrköping", "Jönköping",
                "Oslo", "Bergen", "Trondheim", "Stavanger", "Drammen", "Fredrikstad", "Porsgrunn", "Kristiansand", "Ålesund", "Tromsø",
                "Copenhagen", "Aarhus", "Odense", "Aalborg", "Frederiksberg", "Esbjerg", "Randers", "Kolding", "Horsens", "Vejle",
                "Helsinki", "Espoo", "Tampere", "Vantaa", "Oulu", "Turku", "Jyväskylä", "Lahti", "Kuopio", "Pori",
                "Reykjavik", "Kópavogur", "Hafnarfjörður", "Akureyri", "Reykjanesbær", "Garðabær", "Mosfellsbær", "Akranes", "Selfoss", "Seltjarnarnes",
                "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose",
                "London", "Birmingham", "Liverpool", "Nottingham", "Sheffield", "Bristol", "Manchester", "Leicester", "Islington", "Coventry"
            };
            return cities[_random.Next(cities.Count)];
        }

        public string RandomCountry()
        {
            List<string> countries = new List<string> { "Sweden", "Norway", "Denmark", "Finland", "Island", "USA", "England" };
            return countries[_random.Next(countries.Count)];
        }

        public string RandomUserName()
        {
            List<string> userNames = new List<string>
            {
                "Ove", "Dan", "William", "Sara", "Emma", "Olivia", "Noah", "Liam", "Mia", "Luna", "Ella",
                "Alexander", "Erik", "Ava", "Sofia", "Lucas", "Mason", "Benjamin", "Nora", "Isabella", "Zoe",
                "Oliver", "Leo", "Oscar", "Elias", "Amelia", "Lily", "Daniel", "David", "Julia", "Ellie",
                "Caleb", "Jacob", "Samuel", "Emma", "Anna", "Alice", "Ida", "Freja", "Elvira", "Ingrid",
                "Filippa", "Isak", "Anton", "Lukas", "Adam", "Hugo", "Axel", "Ella", "Ebba", "Wilma", "Oliver",
                "Clara", "Alma", "Alva", "Lilly", "Emilia", "Isak", "Charlie", "Louis", "Theo", "Sebastian", "Carl",
                "Eleanor", "Jack", "Charlotte", "Victoria", "Sophie", "Sophia", "Emily", "Mila", "Henry", "Madison", "Scarlett",
                "Lucas", "Mateo", "Valentina", "Johan", "Mikael", "Bjorn", "Hans", "Gunnar", "Mats", "Lennart", "Kristian",
                "Anna", "Linnea", "Elise", "Matilda", "Sigrid", "Emil", "Viktor", "Martin", "Niklas", "Andreas"
            };
            return userNames[_random.Next(userNames.Count)];
        }
        public string RandomStreet()
        {
            List<string> streets = new List<string>
                {
                    "Washington St", "Liberty Ave", "Main St", "Broadway", "Elm St", "Jefferson Dr", "Lincoln Blvd", "Pine Rd", "Madison Ave", "Maple St",
                    "Kungsvägen", "Drottninggatan", "Vasagatan", "Sveavägen", "Storgatan", "Birger Jarlsgatan", "Skolgatan", "Mäster Samuelsgatan", "Hamngatan",
                    "Luntmakargatan", "Karl Johans gate", "Prinsens gate", "Kirkegata", "Torggata", "Grünerløkka", "Bislett", "Frognerveien", "Majorstuen",
                    "Uelands gate", "Holtegata", "Regent Street", "Baker Street", "Oxford Street", "Knightsbridge", "Mayfair", "Carnaby Street", "Whitechapel Road",
                    "Piccadilly", "Kingsway", "Strand", "Rue de Rivoli", "Champs-Élysées", "Boulevard Saint-Michel", "Rue du Faubourg Saint-Antoine", "Avenue des Gobelins",
                    "Boulevard de la Chapelle", "Rue de la Roquette", "Avenue de Clichy", "Boulevard Voltaire", "Rue Oberkampf"
                };
            return streets[_random.Next(streets.Count)] + " " + _random.Next(1, 200).ToString(); // Adds a random street number
        }

        public string RandomCategory()
        {
            List<string> categories = new List<string>
                {
                    "Historical", "Natural", "Cultural", "Recreational", "Technical", "Architectural", "Religious", "Artistic", "Aquatic", "Biological", "Religious", "Geological", "Eco", "Wildlife"
                };
            return categories[_random.Next(categories.Count)];
        }

        private HashSet<string> generatedAttractionNames = new HashSet<string>();

        public string RandomAttractionName()
        {
            List<string> startWords = new List<string>
            {
                "House", "Tower", "Forest", "Castle", "Garden", "Bridge", "Statue", "Mountain", "River", "Fountain",
                "Cave", "Palace", "Pyramid", "Museum", "Lighthouse", "Valley", "Canyon", "Monument", "Arch", "Island",
                "Fort", "Volcano", "Temple", "Mausoleum", "Cathedral", "Arena", "Gate", "Plaza", "Hill", "Beach"
            };

            List<string> fillerWords = new List<string>
             {
                "of", "in", "like", "at", "with", "without", "under", "over", "by", "near",
                "above", "beyond", "between", "around", "across"
            };

            List<string> endWords = new List<string>
            {
                "Fire", "Flames", "Skies", "Waters", "Dreams", "Legends", "Sands", "Mysteries", "Echoes", "Stars",
                "Moon", "Sun", "Riddles", "Mists", "Shadows", "Songs", "Silence", "Stone", "Gold", "Visions",
                "Time", "Dawn", "Dusk", "Whispers", "Secrets", "Lights", "Storms", "Tales", "Sorrows", "Winds"
            };

            string attractionName;

            // Generate names until a unique one is found
            do
            {
                attractionName = $"{startWords[_random.Next(startWords.Count)]} " +
                                 $"{fillerWords[_random.Next(fillerWords.Count)]} " +
                                 $"{endWords[_random.Next(endWords.Count)]}";
            } while (generatedAttractionNames.Contains(attractionName));

            generatedAttractionNames.Add(attractionName);

            return attractionName;
        }

    }
}