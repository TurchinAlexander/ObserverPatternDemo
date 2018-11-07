using System;
using System.Timers;

namespace ObserverPatternDemo.Implemantation.Observable
{
    public class WeatherData : IObservable<WeatherInfo>
    {
		private Random random = new Random();
		private WeatherInfo _weatherInfo;
		private event Action<object, WeatherInfo> notifier = delegate { };

		public WeatherData()
		{
			int interval = 2000;
			Timer timerInfo = new Timer(interval);

			timerInfo.Elapsed += OnTimerEvent;
			timerInfo.AutoReset = true;
			timerInfo.Enabled = true;
		}

		/// <summary>
		/// Notify all subscribers about new state.
		/// </summary>
		/// <param name="sender">The element with new state.</param>
		/// <param name="info">The state.</param>
        protected virtual void Notify(WeatherInfo info)
        {
			notifier(this, info);
        }

		void IObservable<WeatherInfo>.Notify(WeatherInfo info)
		{
			Notify(info);
		}

		/// <summary>
		/// Register new subscriber.
		/// </summary>
		/// <param name="observer">New subscriber.</param>
        public void Register(IObserver<WeatherInfo> observer)
        {
			notifier += observer.Update;
        }

		/// <summary>
		/// Remove the subscriber.
		/// </summary>
		/// <param name="observer">The subscriber.</param>
		public void Unregister(IObserver<WeatherInfo> observer)
        {
			notifier -= observer.Update;
		}

		private void GenerateNewInfo()
		{
			int temperature = random.Next(0, 30);
			int humidity = random.Next(0, 100);
			int pressure = random.Next(0, 10000);

			_weatherInfo = new WeatherInfo(temperature, humidity, pressure);
		}

		private void OnTimerEvent(Object source, ElapsedEventArgs e)
		{
			GenerateNewInfo();
			Notify(_weatherInfo);
		}

		public override string ToString()
		{
			return "Weather Station";
		}
	}
}
