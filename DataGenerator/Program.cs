using Bogus;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products;
            List<Indicators> indicators;
            using (var context = new ApplicationDbContext())
            {
                products = context.Products.ToList();
                indicators = context.Indicators.ToList();

                Randomizer.Seed = new Random(3);

                var names = new[] { "Kate", "Vitalii", "Dmytro", "Anna", "Olha" };
                var countries = new[] { "Ukraine", "Russia", "USA", "England", "Australia" };

                DateTime startTime = DateTime.Now;

                //var testUsers = new Faker<TesterUser>()
                //    .RuleFor(u => u.Name, f => f.PickRandom(names))
                //    .RuleFor(u => u.Age, f => f.Random.Number(18, 60))
                //    .RuleFor(u => u.Country, f => f.PickRandom(countries))
                //    .RuleFor(u => u.Weight, f => f.Random.Number(45, 100))
                //    .RuleFor(u => u.Height, f => f.Random.Number(145, 210))
                //    .FinishWith((f, u) =>
                //    {
                //        context.TesterUsers.Add(u);
                //        context.SaveChanges();
                //    });

                //var testIndicators = new Faker<Indicators>()
                //    .RuleFor(o => o.TesterUser, f => testUsers.Generate(1).First())
                //    .RuleFor(o => o.Product, f => products[f.Random.Number(0, products.Count - 1)])
                //    .FinishWith((f, u) =>
                //    {
                //        context.Indicators.Add(u);
                //        context.SaveChanges();
                //    });

                //var testIndicatorsInfo = new Faker<IndicatorsInfo>()
                //    .RuleFor(o => o.Indicators, indicators[4])
                //    .RuleFor(o => o.Pulse, f => f.Random.Number(60, 100))
                //    .RuleFor(o => o.Time, f => startTime)
                //    .RuleFor(o => o.BloodOxygenLevel, f => f.Random.Number(88, 99))
                //    .RuleFor(o => o.BloodPressure, f => f.Random.Number(110, 180))
                //    .RuleFor(o => o.Temperature, f => f.Random.Double(36, 39))
                //    .FinishWith((f, u) =>
                //    {
                //        context.IndicatorsInfo.Add(u);
                //        context.SaveChanges();
                //    });

               // var testIndicatorsInfos = testIndicatorsInfo.Generate(5);
            
            }
            
        }
    }
}
