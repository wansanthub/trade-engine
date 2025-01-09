using TradeEngine.Core.Entities;
using TradeEngine.Core.Interfaces;
using TradeEngine.Infrastructure;

namespace TradeEngine.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading trade data from 'trades.txt'...");

            try
            {
                var fileReaderService = new FileReaderService();
                var (referenceDate, tradesData) = fileReaderService.ReadTradesFromFile();

                var trades = new List<ITrade>();
                foreach (var tradeData in tradesData)
                {
                    ITrade trade = new Trade(tradeData.Value, tradeData.ClientSector, tradeData.NextPaymentDate,referenceDate);
                    trades.Add(trade);
                }

                Console.WriteLine($"Reference Date: {referenceDate.ToShortDateString()}");
                Console.WriteLine("\nClassified Trades:");

                foreach (var trade in trades)
                {
                    Console.WriteLine($"Value: {trade.Value}, Sector: {trade.ClientSector}, Next Payment: {trade.NextPaymentDate.ToShortDateString()}, Category: {trade.Category}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}