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

			report.StartMail(weather);
			currentReport.StartMail(weather);

			ConsoleKey command;
			Console.WriteLine("Press Q to watch current weather or ESC to stop.");
			do
			{
				while(!Console.KeyAvailable) { }
				command = Console.ReadKey(true).Key;

				if (command == ConsoleKey.Q)
				{
					Console.WriteLine(currentReport);
				}
			}
			while (command != ConsoleKey.Escape);


			Console.WriteLine("All records:");
			Console.WriteLine(report.ToString());

			Console.ReadKey();
        }
    }
}
