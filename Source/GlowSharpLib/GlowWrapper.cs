using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public partial class GlowSharp
{

    //All the informations that need to be stored
    public GlowSharp.Config Configuration = new GlowSharp.Config();
    
    //Call api/nupnp to get the Bridge-IP
    public bool FindHuebridgeIP()
    {
        dynamic Response = GlowSharp.Helper.GET("https://www.meethue.com/api/nupnp");

        if (Response.HasValues)
        {
            this.Configuration.HuebridgeIP = Response[0].internalipaddress;

            return true;
        }
        else
        {
            return false;
        }
    }
    
    //This function calls /api to register a new device
    public GlowSharp.Models.Wrapper.RegisterDeviceResponse RegisterDevice()
    {
        if (this.Configuration.HuebridgeIP != "") //Check if the Huebridge-IP is allready set
        {
            //Register the device by using the MachineName and the application-Name (Configuration)
            dynamic Response = GlowSharp.Helper.POST("http://" + this.Configuration.HuebridgeIP + "/api",
                                            new { devicetype = this.Configuration.ApplicationName+"#" + Environment.MachineName });

            if (Response[0].error != null)
            {
                return new GlowSharp.Models.Wrapper.RegisterDeviceResponse()
                {
                    success = false,
                    error = Response[0].error.description.ToString()
                };
            }
            else
            {
                this.Configuration.HuebridgeIP = Response[0].success.username;

                return new GlowSharp.Models.Wrapper.RegisterDeviceResponse()
                {
                    success = true,
                    error = ""
                };
            }
        }
        else
        {
            return new GlowSharp.Models.Wrapper.RegisterDeviceResponse()
            {
                success = false,
                error = "Huebridge-IP is not set. Call FindHuebridgeIP()"
            };
        }
    }

    //Update a light-state
    public GlowSharp.Models.Wrapper.UpdateLightRequest UpdateLight(int LightID, GlowSharp.Models.State LightState)
    {
        dynamic Response = GlowSharp.Helper.PUT("http://" + this.Configuration.HuebridgeIP + "/api/" + this.Configuration.getDeviceID() + "/lights/"+LightID+"/state",LightState);

        if(Response != null)
        {
            return new GlowSharp.Models.Wrapper.UpdateLightRequest() { success = true };
        }
        else
        {
            return new GlowSharp.Models.Wrapper.UpdateLightRequest() { success = false };
        }
    }

    //Get all lights from the Huebridge
    public GlowSharp.Models.Wrapper.ListLightsResponse ListLights()
    {
        dynamic Response = GlowSharp.Helper.GET("http://" + this.Configuration.HuebridgeIP + "/api/" + this.Configuration.getDeviceID() + "/lights");

        if (Response != null)
        {
            Dictionary<int, GlowSharp.Models.Light> Lights = new Dictionary<int, GlowSharp.Models.Light>();
            
            bool error = false;
            int currentDOM = 1;
            
            //Search through all sub-Elements until we found something
            while(!error)
            {
                if (Response[currentDOM.ToString()] == null)
                {
                    error = true;
                    break;
                }
                
                //Not that clean right now: String -> Dynamic -> String -> Light-Object
                Lights.Add(currentDOM, JsonConvert.DeserializeObject<GlowSharp.Models.Light>(Response[currentDOM.ToString()].ToString()));

                currentDOM++;
            }

            return new GlowSharp.Models.Wrapper.ListLightsResponse()
            {
                success = true,
                Lights = Lights
            };
        }
        else
        {
            return new GlowSharp.Models.Wrapper.ListLightsResponse()
            {
                success = false,
                error = "No Response"
            };
        }

    }
}

