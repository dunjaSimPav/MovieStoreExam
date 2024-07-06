using System;
using System.Collections.Generic;
using System.Linq;
using MovieStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Humanizer.Localisation;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using sib_api_v3_sdk.Model;
using System.Buffers.Text;
using System.Diagnostics;

namespace MovieStore.Repository.DbSeed
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            DatabaseContext _context = appBuilder
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DatabaseContext>();

            if (_context.Database.GetPendingMigrations().Any())
                _context.Database.Migrate();


            var anyArticles = _context.Articles.Any();

            if (!anyArticles)
            {

                using var transaction = _context.Database.BeginTransaction();
                var ArticleTypes = GetMainArticleTypes();
                _context.ArticleTypes.AddRange(ArticleTypes);

                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ArticleTypes ON;");
                _context.SaveChanges();
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ArticleTypes OFF;");
                transaction.Commit();

                var articles = GetArticles();

                _context.Articles.AddRange(articles);
                _context.SaveChanges();
            }
        }

        static List<string> GetTableNames(this DatabaseContext context)
        {
            return new List<string>()
            {
                "Articles", "ArticleTypes", "ArticleArticleTypes"
            };
        }

        static List<Article> GetArticles()
        {
            return new List<Article>()
            {
                new Article()
                {
                    Name = "The Vanished",
                    Description = "A Civil War veteran agrees to deliver a girl, taken by the Kiowa people years ago, to her aunt and uncle, against her will. They travel hundreds of miles and face grave dangers as they search for a place that either can call home.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 4,
                    Image = "/assets/products/theVanished.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Die Hard",
                    Description = "This film follows New York City police detective John McClane who is caught up in a terrorist takeover of a Los Angeles skyscraper while visiting his estranged wife.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 4,
                    Image = "/assets/products/dieHardd.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Taken",
                    Description = "A retired CIA agent travels across Europe and relies on his old skills to save his estranged daughter, who has been kidnapped while on a trip to Paris.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 4,
                    Image = "/assets/products/tt.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "One Night in Miami",
                    Description = "A fictional account of one incredible night where icons Muhammad Ali, Malcolm X, Sam Cooke, and Jim Brown gathered discussing their roles in the Civil Rights Movement and cultural upheaval of the 60s.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 6,
                    Image = "/assets/products/oneNightInMiami.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Dune",
                    Description = "A mythic and emotionally charged hero's journey, \"Dune\" tells the story of Paul Atreides, a brilliant and gifted young man born into a great destiny beyond his understanding, who must travel to the most dangerous planet in the universe to ensure the future of his family and his people.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 5,
                    Image = "/assets/products/dune.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Napoleon",
                    Description = "A Golden Retriever puppy living with a loving family in Australia, dreams of being a wild dog. During a birthday party, a balloon-lined basket accidentally carries him away from home. Eventually landing on Sydney's coastline, Napoleon is excited to be in the wilderness.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 3,
                    Image = "/assets/products/napoleon.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Home Alone",
                    Description = "An eight-year-old troublemaker, mistakenly left home alone, must defend his home against a pair of burglars on Christmas Eve.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 3,
                    Image = "/assets/products/homeAlone.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "The Shawshank Redemption",
                    Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 6,
                    Image = "/assets/products/redemption.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "12 Angry Men",
                    Description = "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 6,
                    Image = "/assets/products/12angry.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Avatar",
                    Description = "The films follow a U.S. Marine named Jake Sully who becomes part of a program in which human colonizers explore and exploit an alien world called Pandora.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 5,
                    Image = "/assets/products/avatar.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Palm Springs",
                    Description = "When carefree Nyles and reluctant maid of honor Sarah have a chance encounter at a Palm Springs wedding, things get complicated as they are unable to escape the venue, themselves, or each other.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 1,
                    Image = "/assets/products/palmSprings.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "The Witches",
                    Description = "A young boy and his grandmother have a run-in with a coven of witches and their leader.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 5,
                    Image = "/assets/products/theWithces.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Coco",
                    Description = "The story follows a 12-year-old boy named Miguel who is accidentally transported to the Land of the Dead, where he seeks the help of his deceased musician great-great-grandfather to return him to his family and reverse their ban on music.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 2,
                    Image = "/assets/products/coco.jfif",
                    Tags = ""
                },
                new Article()
                {
                    Name = "Inside Out",
                    Description = "A girl named Riley is born in Minnesota, and within her mind, five personifications of her core emotions-Joy, Sadness, Disgust, Fear, and Anger-come to life.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 2,
                    Image = "/assets/products/insideout.jfif",
                    Tags = ""
                },
                 new Article()
                 {
                    Name = "Up",
                    Description = "78-year-old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 2,
                    Image = "/assets/products/up.jfif",
                    Tags = ""
                 },
                 new Article()
                 {
                    Name = "Rush Hour",
                    Description = "A loyal and dedicated Hong Kong Inspector teams up with a reckless and loudmouthed L.A.P.D. detective to rescue the Chinese Consul's kidnapped daughter, while trying to arrest a dangerous crime lord along the way.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 1,
                    Image = "/assets/products/rushHour.jfif",
                    Tags = ""
                 },
                 new Article()
                 {
                    Name = "Barbie",
                    Description = "The film follows them on a journey of self-discovery through Barbieland and the real world following an existential crisis.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 1,
                    Image = "/assets/products/barbie.jfif",
                    Tags = ""
                 },
                 new Article()
                 {
                    Name = "Matilda",
                    Description = "The plot centers on the titular child prodigy who develops psychokinetic abilities and uses them to deal with her disreputable family and the tyrannical principal of her school.",
                    Price = GetRandomPrice(),
                    ArticleTypeId = 3,
                    Image = "/assets/products/matilda.jfif",
                    Tags = ""
                 },
            };
        }

        private static string GetRandomArticleType()
        {
            var random = new Random();
            var ArticleTypes = GetMainArticleTypes();
            var ArticleTypesCount = ArticleTypes.Count;
            int numRandomArticleType = random.Next(1, ArticleTypesCount);

            return ArticleTypes[numRandomArticleType].Name;
        }

        private static decimal GetRandomPrice()
        {
            var random = new Random();
            var basePrice = (decimal)(random.Next(6, 75) * 1.0);
            var decimalPrice = (decimal)(random.NextDouble() * 99);
            return basePrice + decimalPrice;
        }

        static List<ArticleType> GetMainArticleTypes()
        {
            /*
                1	Comedy	It is a genre of movie which is mainly humorous.
                2	Cartoon	Genre in which individual drawings, paintings, or illustrations are photographed frame by frame (stop-frame cinematography)
                3	Family	Genre that generally relates to children in the context of home and family
                4	Action	Genre that predominantly features chase sequences, fights, shootouts, explosions, and stunt work
                5	Sci-Fi	Genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, spacecraft, robots, cyborgs, mutants, interstellar travel, time travel, or other technologies
                6	Drama	Category or genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone
             */
            return new List<ArticleType>()
            {
                new ArticleType() { ArticleTypeId = 1, Name = "Comedy", Description = "It is a genre of movie which is mainly humorous." },
                new ArticleType() { ArticleTypeId = 2, Name = "Cartoon", Description = "Genre in which individual drawings, paintings, or illustrations are photographed frame by frame (stop-frame cinematography" },
                new ArticleType() { ArticleTypeId = 3, Name = "Family", Description = "Genre that generally relates to children in the context of home and family" },
                new ArticleType() { ArticleTypeId = 4, Name = "Action", Description = "Genre that predominantly features chase sequences, fights, shootouts, explosions, and stunt work" },
                new ArticleType() { ArticleTypeId = 5, Name = "Sci-Fi", Description = "Genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science, such as extraterrestrial lifeforms, spacecraft, robots, cyborgs, mutants, interstellar travel, time travel, or other technologies" },
                new ArticleType() { ArticleTypeId = 6, Name = "Drama", Description = "Category or genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone" }
            };
        }
    }
}
