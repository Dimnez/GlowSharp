using System.Collections.Generic;

public partial class GlowSharp
{
    public partial class Models
    {
        //Hue-Wrapper Response
        public class Wrapper
        {
            //Response for RegisterDevice()
            public class RegisterDeviceResponse
            {
                public bool success;
                public string error;
            }

            //Response for UpdateLightRequest()
            public class UpdateLightRequest
            {
                public bool success;
                public string error;
            }

            //Response for ListDevices()
            public class ListLightsResponse
            {
                public Dictionary<int, GlowSharp.Models.Light> Lights;
                public bool success;
                public string error;
            }
        }
    }
}