using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapClasses
{
    public class Rain
    {
        [JsonProperty(PropertyName = "3h")]
        public double _3h { get; set; }
    }
}
