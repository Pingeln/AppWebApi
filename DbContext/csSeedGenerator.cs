using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using Models;
using DbModels;
using DbContext;

public class csSeedGenerator
{
    private readonly csMainDbContext _context;
    private readonly RandomDataGenerator _randomDataGenerator;

    public csSeedGenerator(csMainDbContext context)
    {
        _context = context;
        _randomDataGenerator = new RandomDataGenerator();
    }

    public void GenerateData()
    {
        // Seeding Addresses
        var addresses = GenerateAddresses(10); // Generating 10 addresses as an example
        _context.Address.AddRange(addresses);

        // Seeding Users
        var users = GenerateUsers(10); // Generating 10 users as an example
        _context.Users.AddRange(users);

        // Seeding Attractions
        var attractions = GenerateAttractions(10, addresses); // Generating 10 attractions
        _context.Attraction.AddRange(attractions);

        // Seeding Comments
        var comments = GenerateComments(50, users, attractions); // Generating 50 comments
        _context.Comment.AddRange(comments);

        _context.SaveChanges();
    }

    private List<csAddressDbM> GenerateAddresses(int count)
    {
        var list = new List<csAddressDbM>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new csAddressDbM
            {
                AddressID = Guid.NewGuid(),
                Street = _randomDataGenerator.RandomString(10),
                City = _randomDataGenerator.RandomString(6),
                Country = _randomDataGenerator.RandomString(8),
                ZipCode = _randomDataGenerator.RandomString(5)
            });
        }
        return list;
    }

    private List<csUserDbM> GenerateUsers(int count)
    {
        var list = new List<csUserDbM>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new csUserDbM
            {
                UserID = Guid.NewGuid(),
                UserName = _randomDataGenerator.RandomString(7)
            });
        }
        return list;
    }

    private List<csAttractionDbM> GenerateAttractions(int count, List<csAddressDbM> addresses)
    {
        var list = new List<csAttractionDbM>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new csAttractionDbM
            {
                AttractionID = Guid.NewGuid(),
                Name = _randomDataGenerator.RandomString(8),
                Category = _randomDataGenerator.RandomString(6),
                Description = _randomDataGenerator.RandomString(20),
                AddressID = addresses[_randomDataGenerator.RandomNumber(0, addresses.Count)].AddressID
            });
        }
        return list;
    }

    private List<csCommentDbM> GenerateComments(int count, List<csUserDbM> users, List<csAttractionDbM> attractions)
    {
        var list = new List<csCommentDbM>();
        for (int i = 0; i < count; i++)
        {
            list.Add(new csCommentDbM
            {
                CommentID = Guid.NewGuid(),
                Text = _randomDataGenerator.RandomString(25),
                UserID = users[_randomDataGenerator.RandomNumber(0, users.Count)].UserID,
                AttractionID = attractions[_randomDataGenerator.RandomNumber(0, attractions.Count)].AttractionID
            });
        }
        return list;
    }
}
