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
                new Game() {  Id = 1, Title = "Fallout 4" },
                new Game() {  Id = 2, Title = "League of Legends"}
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
