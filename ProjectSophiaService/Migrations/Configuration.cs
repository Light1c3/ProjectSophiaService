namespace ProjectSophiaService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProjectSophiaService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectSophiaService.Models.ProjectSophiaServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectSophiaService.Models.ProjectSophiaServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Games.AddOrUpdate(x => x.Id,
                new Game()
                {
                    Id = 1,
                    Title = "Fallout 4",
                    Year = 2015,
                    Publisher = "Bathesda",
                    Description = "Fallout 4 is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. The fifth major installment in the Fallout series...",
                    ImageUrl = "https://imgrszr-prod.s3.amazonaws.com/1_400--5c49c9942a51f3ad29244289a5de762f641b42cc.png"
                },
                 new Game()
                 {
                     Id = 2,
                     Title = "Leageu Of Legends",
                     Year = 2009,
                     Publisher = "Riot Games",
                     Description = "League of Legends is a Free2Play game developed by Riot Games. It is refered to as a MOBA (Multiplayer Online Battle Areana), and currently has the biggest active userbase in any game.",
                     ImageUrl = "http://d2rhekw5qr4gcj.cloudfront.net/img/400sqf/from/uploads/course_photos/14091_lol.jpg"
                 },
                 new Game()
                 {
                     Id = 3,
                     Title = "Battlefield 4",
                     Year = 2013,
                     Publisher = "Electronic Arts",
                     Description = "Fallout 4 is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. The fifth major installment in the Fallout series...",
                     ImageUrl = "http://d10e5q7gdrohow.cloudfront.net/wp-content/uploads/2014/02/battle-field-4-400x400.jpg"
                 }, new Game()
                 {
                     Id = 4,
                     Title = "Battlefront",
                     Year = 2015,
                     Publisher = "Electronic Arts",
                     Description = "Fallout 4 is an open world action role-playing video game developed by Bethesda Game Studios and published by Bethesda Softworks. The fifth major installment in the Fallout series...",
                     ImageUrl = "http://www.offgamers.com/blog/wp-content/uploads/2015/11/Star-Wars-Battlefront.jpg"
                 }
                );

            context.Benchmarks.AddOrUpdate(x => x.Id,
                new Benchmark()
                {
                    Id = 1,
                    Username = "Light1c3",
                    GameId = 2,
                    CPU = "Intel i7 3770K",
                    GPU = "MSI GTX 970",
                    RAM = "G.Skill 2300Mhz DDR3",
                    AvgFPS = "160",
                    MaxFPS = "300",
                    MinFPS = "110"
                }, 
                new Benchmark()
                {
                    Id = 2,
                    Username = "St.EEEEVE",
                    GameId = 1,
                    CPU = "Potato",
                    GPU = "Integrated Potato",
                    RAM = "MetalPower 2Khz DDR0",
                    AvgFPS = "1",
                    MaxFPS = "3",
                    MinFPS = "0"
                }
                );
        }
    }
}
