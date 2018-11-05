using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
		Random random = new Random();
		private WeatherInfo _weatherInfo;
		private List<IObserver<WeatherInfo>> listSubs = new List<IObserver<WeatherInfo>>();

		public void CheckData()
		{
			int temperature = random.Next(0, 30);
			int humidity = random.Next(0, 100);
			int pressure = random.Next(0, 10000);

			_weatherInfo = new WeatherInfo(temperature, humidity, pressure);

			((IObservable<WeatherInfo>)this).Notify(this, _weatherInfo);
		}

		/// <summary>
		/// Notify all subscribers about new state.
		/// </summary>
		/// <param name="sender">The element with new state.</param>
		/// <param name="info">The state.</param>
        void IObservable<WeatherInfo>.Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
			for (int i = 0; i < listSubs.Count; i++)
			{
				listSubs[i].Update(sender, info);
			}
        }

		/// <summary>
		/// Register new subscriber.
		/// </summary>
		/// <param name="observer">New subscriber.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (!listSubs.Contains(observer))
			{
				listSubs.Add(observer);
			}
        }

		/// <summary>
		/// Remove the subscriber.
		/// </summary>
		/// <param name="observer">The subscriber.</param>
		public void Unregister(IObserver<WeatherInfo> observer)
        {
			if (listSubs.Contains(observer))
			{
				listSubs.Remove(observer);
			}
		}
    }
}
