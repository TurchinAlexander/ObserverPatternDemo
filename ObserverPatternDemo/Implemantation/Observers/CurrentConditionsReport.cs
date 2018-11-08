using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport
	{
		private WeatherInfo _weatherInfo;
		private object _sender;

		/// <summary>
		/// Method to take new mail with WeatherInfo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="info"></param>
		public void Update(object sender, WeatherInfo info)
        {
			_weatherInfo = info;
			_sender = sender;
        }

		public override string ToString()
		{
			return $"{_sender}: {_weatherInfo}";
		}
	}
}