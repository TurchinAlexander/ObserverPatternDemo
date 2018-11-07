using ObserverPatternDemo.Implemantation.Observable;
using System;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
		private WeatherInfo _weatherInfo;
		private object _sender;

		public void StartMail(IObservable<WeatherInfo> observable)
		{
			observable.Register(this);
		}

		public void StopMail(IObservable<WeatherInfo> observable)
		{
			observable.Unregister(this);
		}

		void IObserver<WeatherInfo>.Update(object sender, WeatherInfo info)
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