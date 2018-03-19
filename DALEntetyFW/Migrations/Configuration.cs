using DALEntetyFW.DataModels;

namespace DALEntetyFW.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Concrete.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DALEntetyFW.Concrete.DataContext context)
        {
            context.Categories.AddOrUpdate(
                    new Category
                    {
                        CategoryID = 1,
                        CategoryName = "Category1"
                    }, 
                    new Category
                    {
                        CategoryID = 2,
                        CategoryName = "Category2"
                    },
                    new Category
                    {
                        CategoryID = 3,
                        CategoryName = "Category3"
                    });

            context.Regions.AddOrUpdate(
                new Region
                {
                    RegionID = 1,
                    RegionDescription = "RegionDescription1"
                },
                new Region
                {
                    RegionID = 2,
                    RegionDescription = "RegionDescription2"
                },
                new Region
                {
                    RegionID = 3,
                    RegionDescription = "RegionDescription3"
                });

            context.Territories.AddOrUpdate(
                new Territory
                {
                    RegionID = 1,
                    TerritoryID = "11111",
                    TerritoryDescription = "TerritoryDescription1"
                },
                new Territory
                {
                    RegionID = 2,
                    TerritoryID = "22222",
                    TerritoryDescription = "TerritoryDescription2"
                },
                new Territory
                {
                    RegionID = 3,
                    TerritoryID = "33333",
                    TerritoryDescription = "TerritoryDescription3"
                });
        }
    }
}
