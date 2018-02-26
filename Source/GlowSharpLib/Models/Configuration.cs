using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class GlowSharp
{
    //Simple Configuration-Class
    //Application will be used when you register the Device for the first time
    public class Config
    {
        public string ApplicationName = "GlowSharp"; //Name of your Application
        public string HuebridgeIP = ""; 
        private string HueDeviceID = "";
       
        public string getDeviceID()
        {
            return HueDeviceID;
        }
    }
}
