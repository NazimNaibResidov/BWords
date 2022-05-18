using Bogus;
using BWords.Api.Domain.Models;
using BWords.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.Context
{
    internal class SeedData
    {
        public static List<User> GetUser()
        {
            var result = new Faker<User>("tr")
                .RuleFor(x => x.Id, x => Guid.NewGuid())
                .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(x => x.FristName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .RuleFor(x => x.UserName, x => x.Internet.UserName())
                .RuleFor(x => x.Password, x => PasswordEncryption.Encrypt( x.Internet.Password()))
                .RuleFor(x => x.EmailConfirmed, x => x.PickRandom(true, false))
                .Generate(500);
            return result;

        }
        public async Task SeedAsync(IConfiguration configuration)
        {
            
            var dbcontextBuilder = new DbContextOptionsBuilder();
            dbcontextBuilder.UseSqlServer(configuration.GetConnectionString("BWords"));
            
            var context = new BWordsContext(dbcontextBuilder.Options);
            context.Database.Migrate();
            if (context.Users.Any())
              await  Task.CompletedTask;
            var users = GetUser();
            var userid = users.Select(x => x.Id);
            await context.Users.AddRangeAsync(users);
            var giuds = Enumerable.Range(0, 200).Select(x => Guid.NewGuid()).ToList();
            int counter = 0;
            var entites = new Faker<Entiry>("tr")
                .RuleFor(x => x.Id, x => giuds[counter++])
                .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(x => x.Subject, x => x.Lorem.Sentence(5, 5))
                .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
                .RuleFor(x => x.CreateById, x => x.PickRandom(userid))
                .Generate(200);
          //  await context.Entiries.AddRangeAsync(entites);

            await context.SaveChangesAsync();
            var idds = context.Entiries.Select(x => x.Id).ToList();
            var comments=new Faker<EntryComment>("tr")
                .RuleFor(x=>x.Id,x=>Guid.NewGuid())
                .RuleFor(x => x.CreateDate, x => x.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
                .RuleFor(x => x.Content, x => x.Lorem.Paragraph(2))
                .RuleFor(x => x.CreateById, x => x.PickRandom(userid))
                .RuleFor(x => x.EntiryId, x => x.PickRandom(idds))
                .Generate(200);
            await context.EntryComments.AddRangeAsync(comments);
            await context.SaveChangesAsync();



        }
    }
}
