using System;

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

			weather.Data = new WeatherInfo(10, 10, 10);
			weather.Data = new WeatherInfo(2, 15, 10);

			Console.WriteLine(currentReport.ToString());
			Console.WriteLine();
			Console.WriteLine(report.ToString());

			Console.ReadKey();
        }
    }
}
