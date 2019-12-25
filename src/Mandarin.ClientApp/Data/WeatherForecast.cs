// Copyright 2019-2019 (c) Bashi. All rights reserved.
// Licensed under the BSD-3-Clause license. See BSD-3-Clause.md for full details.

using System;

namespace Mandarin.ClientApp.Data
{
    /// <summary>
    /// Describes a daily weather forecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date the forecast is for.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the forecasted temperature for the day (in celsius).
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the forecasted temperature for the day (in fahrenheit).
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the forecasted general description for the day.
        /// </summary>
        public string? Summary { get; set; }
    }
}
