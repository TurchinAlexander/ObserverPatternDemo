using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
		private WeatherInfo _weatherInfo;
		private IObservable<WeatherInfo> _sender;

		void IObserver<WeatherInfo>.Update(IObservable<WeatherInfo> sender, WeatherInfo info)
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