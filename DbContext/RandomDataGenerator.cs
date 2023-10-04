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

            /// <summary>
            /// Generates a random string with the given length.
            /// </summary>
            /// <param name="length">The length of the string.</param>
            /// <returns>A random string.</returns>
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

            /// <summary>
            /// Generates a random number between the given minimum and maximum values.
            /// </summary>
            /// <param name="min">The minimum value (inclusive).</param>
            /// <param name="max">The maximum value (exclusive).</param>
            /// <returns>A random number.</returns>
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

                //... Add up to 100 cities or as many as you want
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
        }
}
    