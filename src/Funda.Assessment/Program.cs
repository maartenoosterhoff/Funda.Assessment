using System;

using Funda.Assessment.Entities;
using Funda.Assessment.Implementations;
using Funda.Assessment.Interfaces;

namespace Funda.Assessment
{
    public class Program
    {
        private const string UrlAlleData = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/&page={0}&pagesize=100";
        private const string UrlAlleDataMetTuin = "http://partnerapi.funda.nl/feeds/Aanbod.svc/json/005e7c1d6f6c4f9bacac16760286e3cd/?type=koop&zo=/amsterdam/tuin/&page={0}&pagesize=100";

        public static void Main(string[] args)
        {
            // Make sure we can display unicode characters.
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // In bigger applications this would be moved to the composition root.
            IDataRetriever dataRetriever = new JsonDataRetriever();
            IDataAggregator<FundaDataResult> aggregator = new FundaDataAggregator(dataRetriever);
            IDataCalculator calculator = new Top10MakelaarsCalculator();

            // Retrieve, aggregate, calculate and display.
            calculator.CalculateAndDisplay(aggregator.GetAll(UrlAlleData), "Top 10 Makelaars met de meeste objecten");
            calculator.CalculateAndDisplay(aggregator.GetAll(UrlAlleDataMetTuin), "Top 10 Makelaars met de meeste objecten met tuin");

            Console.ReadLine();
        }
    }
}
