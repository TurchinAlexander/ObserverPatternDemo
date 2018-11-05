using System;
using System.Threading;

using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
			WeatherData weather = new WeatherData();

			StatisticReport report = new StatisticReport();
			CurrentConditionsReport currentReport = new CurrentConditionsReport();

			weather.Register(report);
			weather.Register(currentReport);

			Console.WriteLine("Press ESC to stop.");
			int sleepTime = 1000;
			do
			{
				while (!Console.KeyAvailable)
				{
					weather.CheckData();
					Thread.Sleep(sleepTime);
					Console.WriteLine(currentReport.ToString());
				}
			}
			while (Console.ReadKey(true).Key != ConsoleKey.Escape);


			Console.WriteLine("All records:");
			Console.WriteLine(report.ToString());

			Console.ReadKey();
        }
    }
}
