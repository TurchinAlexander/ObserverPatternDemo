using System;
using System.Text;
using System.Collections.Generic;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class StatisticReport
    {
		List<WeatherInfo> listWeatherInfo = new List<WeatherInfo>();

		/// <summary>
		/// Method to take new mail with WeatherInfo.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="info"></param>
		public void Update(object sender, WeatherInfo info)
        {
			listWeatherInfo.Add(info);
        }

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < listWeatherInfo.Count; i++)
			{
				stringBuilder.Append(listWeatherInfo[i].ToString());
				stringBuilder.Append("\n");
			}

			return stringBuilder.ToString();
		}
	}
}
