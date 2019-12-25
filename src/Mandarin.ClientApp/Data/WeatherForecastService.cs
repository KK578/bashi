// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mandarin.ClientApp.Data
{
    /// <summary>
    /// A service that provides a forecast for the weather of upcoming days.
    /// </summary>
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private readonly Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastService"/> class.
        /// </summary>
        public WeatherForecastService()
        {
            this.random = new Random();
        }

        /// <summary>
        /// Gets the forecast for the next 5 days, starting from <paramref name="startDate"/>.
        /// </summary>
        /// <param name="startDate">The first day the forecast should start from.</param>
        /// <returns>A random description of forecasts for the next 5 days..</returns>
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = this.random.Next(-20, 55),
                Summary = Summaries[this.random.Next(Summaries.Length)],
            }).ToArray());
        }
    }
}
