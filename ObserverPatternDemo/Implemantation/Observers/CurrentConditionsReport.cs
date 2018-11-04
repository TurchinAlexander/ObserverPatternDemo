using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
		private WeatherInfo _weatherInfo;

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
			_weatherInfo = info;
        }

		public override string ToString()
		{
			return $"{_weatherInfo}";
		}
	}
}