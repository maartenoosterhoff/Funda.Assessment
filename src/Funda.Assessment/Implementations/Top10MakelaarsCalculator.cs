using System;
using System.Linq;

using Funda.Assessment.Entities;
using Funda.Assessment.Interfaces;

namespace Funda.Assessment.Implementations
{
    public class Top10MakelaarsCalculator : IDataCalculator
    {
        public void CalculateAndDisplay(FundaDataResult data, string title)
        {
            // Calculate top 10
            var makelaars = data.Objects
                .GroupBy(x => new { x.MakelaarId, x.MakelaarNaam })
                .OrderByDescending(x => x.Count())
                .Take(10)
                .Select(x => new { x.Key.MakelaarId, x.Key.MakelaarNaam, Aantal = x.Count() })
                .ToArray();

            // Display in table.
            const int colWidth1 = 10;
            const int colWidth2 = 50;
            const int colWidth3 = 10;

            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine($"{"Id".PadRight(colWidth1)}{"Naam".PadRight(colWidth2)}{"Aantal".PadRight(colWidth3)}");
            Console.WriteLine($"{string.Empty.PadRight(colWidth1 - 1, '-')} {string.Empty.PadRight(colWidth2 - 1, '-')} {string.Empty.PadRight(colWidth3 - 1, '-')}");

            foreach (var makelaar in makelaars)
            {
                Console.WriteLine($"{makelaar.MakelaarId.ToString().PadRight(colWidth1)}{makelaar.MakelaarNaam.PadRight(colWidth2)}{makelaar.Aantal.ToString().PadRight(colWidth3)}");
            }
            Console.WriteLine();
        }
    }
}
