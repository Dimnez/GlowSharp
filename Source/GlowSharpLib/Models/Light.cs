    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

public partial class GlowSharp
{

    public partial class Models
    {
        public partial class Light
        {
            [JsonProperty("state")]
            public State State { get; set; }

            [JsonProperty("swupdate")]
            public Swupdate Swupdate { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("modelid")]
            public string Modelid { get; set; }

            [JsonProperty("manufacturername")]
            public string Manufacturername { get; set; }

            [JsonProperty("capabilities")]
            public Capabilities Capabilities { get; set; }

            [JsonProperty("uniqueid")]
            public string Uniqueid { get; set; }

            [JsonProperty("swversion")]
            public string Swversion { get; set; }

            [JsonProperty("swconfigid")]
            public string Swconfigid { get; set; }

            [JsonProperty("productid")]
            public string Productid { get; set; }
        }

        public partial class Capabilities
        {
            [JsonProperty("certified")]
            public bool Certified { get; set; }

            [JsonProperty("streaming")]
            public Streaming Streaming { get; set; }
        }

        public partial class Streaming
        {
            [JsonProperty("renderer")]
            public bool Renderer { get; set; }

            [JsonProperty("proxy")]
            public bool Proxy { get; set; }
        }

        public partial class State
        {
            [JsonProperty("on")]
            public bool On { get; set; }

            [JsonProperty("bri")]
            public long Bri { get; set; }

            [JsonProperty("alert")]
            public string Alert { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("reachable")]
            public bool Reachable { get; set; }
        }

        public partial class Swupdate
        {
            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("lastinstall")]
            public System.DateTimeOffset Lastinstall { get; set; }
        }

    }
}