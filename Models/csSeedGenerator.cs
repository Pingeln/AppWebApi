using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using Models;

namespace Models
{
    public class csSeedGenerator : Random
    {
        // Generate random user names
        public string GenerateRandomUserName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah" };
            string[] lastNames = { "Smith", "Doe", "Johnson", "Brown", "Taylor", "Anderson" };

            return $"{firstNames[this.Next(0, firstNames.Length)]} {lastNames[this.Next(0, lastNames.Length)]}";
        }

        // Generate random comments for attractions
        public List<csComment> GenerateRandomComments(int numberOfComments)
        {
            List<csComment> comments = new List<csComment>();
            for (int i = 0; i < numberOfComments; i++)
            {
                var comment = new csComment
                {
                    CommentID = Guid.NewGuid(),
                    Text = GenerateRandomCommentText(),
                    // Set other properties as needed
                };
                comments.Add(comment);
            }
            return comments;
        }

        // Generate random comment text
        public string GenerateRandomCommentText()
        {
            string[] commentTexts = {
                "This is a great attraction!",
                "I really enjoyed my visit here.",
                "The view from this place is amazing.",
                "I would definitely recommend it.",
                // Add more comment texts as needed
            };

            return commentTexts[this.Next(0, commentTexts.Length)];
        }

        // Generate random addresses
        public List<csAddress> GenerateRandomAddresses(int numberOfAddresses)
        {
            List<csAddress> addresses = new List<csAddress>();
            for (int i = 0; i < numberOfAddresses; i++)
            {
                var address = new csAddress
                {
                    AddressID = Guid.NewGuid(),
                    Street = GenerateRandomStreet(),
                    City = GenerateRandomCity(),
                    Country = GenerateRandomCountry(),
                    // Set other properties as needed
                };
                addresses.Add(address);
            }
            return addresses;
        }

        // Generate random street names
        public string GenerateRandomStreet()
        {
            string[] streetNames = {
                "Main Street", "Elm Street", "Oak Avenue", "Maple Drive",
                "Cedar Lane", "Pine Road", "Birch Court", "Willow Lane",
                // Add more street names as needed
            };

            return streetNames[this.Next(0, streetNames.Length)];
        }

        // Generate random cities
        public string GenerateRandomCity()
        {
            string[] cities = {
                "Stockholm", "Oslo", "Copenhagen", "Helsinki",
                // Add more cities as needed
            };

            return cities[this.Next(0, cities.Length)];
        }

        // Generate random countries
        public string GenerateRandomCountry()
        {
            string[] countries = {
                "Sweden", "Norway", "Denmark", "Finland",
                // Add more countries as needed
            };

            return countries[this.Next(0, countries.Length)];
        }
    }
}
