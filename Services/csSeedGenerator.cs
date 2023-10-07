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
        var users = GenerateUsers(50);
        _context.Users.AddRange(users);

        var addresses = GenerateAddresses(100);
        _context.Address.AddRange(addresses);

        var attractions = GenerateAttractions(1000, addresses);
        _context.Attraction.AddRange(attractions);

        var comments = GenerateComments(0, 20, users, attractions);
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
                Street = _randomDataGenerator.RandomStreet(),
                City = _randomDataGenerator.RandomCity(),
                Country = _randomDataGenerator.RandomCountry(),
                ZipCode = _randomDataGenerator.RandomString(5)  // Could rework this later if I want pure digits instead of letters but not necessary for the assignment
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
                UserName = _randomDataGenerator.RandomUserName()
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
                Name = _randomDataGenerator.RandomAttractionName(),
                Category = _randomDataGenerator.RandomCategory(),
                Description = _randomDataGenerator.RandomString(20), 
                AddressID = addresses[_randomDataGenerator.RandomNumber(0, addresses.Count)].AddressID
            });
        }
        return list;
    }

    // comments are just random letters, works fine this way though for now, rework later
    private List<csCommentDbM> GenerateComments(int minComments, int maxComments, List<csUserDbM> users, List<csAttractionDbM> attractions)
    {
        var list = new List<csCommentDbM>();
        foreach (var attraction in attractions)
        {
            int commentCount = _randomDataGenerator.RandomNumber(minComments, maxComments + 1);
            for (int i = 0; i < commentCount; i++)
            {
                list.Add(new csCommentDbM
                {
                    CommentID = Guid.NewGuid(),
                    Text = _randomDataGenerator.RandomString(25),
                    UserID = users[_randomDataGenerator.RandomNumber(0, users.Count)].UserID,
                    AttractionID = attraction.AttractionID
                });
            }
        }
        return list;
    }

}
