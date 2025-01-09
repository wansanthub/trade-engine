using TradeEngine.Core.Enums;
using TradeEngine.Core.Interfaces.IServices;

namespace TradeEngine.Infrastructure
{
    public class FileReaderService : ITradeService
    {
        public (DateTime referenceDate, List<(double Value, ClientSectorEnum ClientSector, DateTime NextPaymentDate)> trades) ReadTradesFromFile()
        {
            var solutionDirectory = FindSolutionDirectory();
            var filePath = Path.Combine(solutionDirectory, "trades.txt");
            var lines = File.ReadAllLines(filePath);
            var referenceDate = DateTime.Parse(lines[0]);
            var numberOfTrades = int.Parse(lines[1]);

            var trades = new List<(double, ClientSectorEnum, DateTime)>();
            for (int i = 2; i < 2 + numberOfTrades; i++)
            {
                var parts = lines[i].Split(' ');
                var value = double.Parse(parts[0]);
                var sector = Enum.Parse<ClientSectorEnum>(parts[1], true);
                var nextPaymentDate = DateTime.Parse(parts[2]);

                trades.Add((value, sector, nextPaymentDate));
            }

            return (referenceDate, trades);
        }

        private string FindSolutionDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            while (!string.IsNullOrEmpty(currentDirectory))
            {
                if (Directory.GetFiles(currentDirectory, "*.sln").Length > 0)
                {
                    return currentDirectory;
                }

                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            return currentDirectory;
        }
    }
}