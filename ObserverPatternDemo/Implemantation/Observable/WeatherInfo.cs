using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherInfo : EventInfo
    {
		public DateTime Time { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }

		public WeatherInfo(int temperature, int humidity, int pressure)
		{
			Time = DateTime.Now;
			Temperature = temperature;
			Humidity = humidity;
			Pressure = pressure;
		}

		public override string ToString()
		{
			return $"{Time.ToString("MM/dd/yyyy HH:mm:ss")}: Temperature — {Temperature}, Humidity — {Humidity}, Pressure — {Pressure}";
		}
	}
}