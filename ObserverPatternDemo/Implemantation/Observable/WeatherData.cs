using System;
using System.Collections.Generic;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
		private WeatherInfo _weatherInfo;

		public WeatherInfo Data
		{
			get { return _weatherInfo; }
			set
			{
				Notify(this, value);
				_weatherInfo = value;
			}
		}

		private List<IObserver<WeatherInfo>> listSubs = new List<IObserver<WeatherInfo>>();

		/// <summary>
		/// Notify all subscribers about new state.
		/// </summary>
		/// <param name="sender">The element with new state.</param>
		/// <param name="info">The state.</param>
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
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
