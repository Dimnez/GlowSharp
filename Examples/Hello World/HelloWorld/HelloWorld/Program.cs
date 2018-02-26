using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        public static GlowSharp Wrapper = new GlowSharp();

        static void Main(string[] args)
        {
       
            Console.WriteLine("Welcome to this GlowSharp Demo Application!");

            //Looking for a Huebridge
            var HueBridge = Wrapper.FindHuebridgeIP();

            if (!HueBridge)
            {
                Console.WriteLine("Sorry, but it seems like there is no Huebridge in your local network :(");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Huebridge found: "+Wrapper.Configuration.HuebridgeIP);
                Console.WriteLine("Please press the sync-button on your bridge / after that: press Enter!");
                Console.Read();

                var register = Wrapper.RegisterDevice();

                while(!register.success)
                {
                    Console.WriteLine("Hue said: "+register.error);
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("Hmm, please press the snyc-button! /after that: press Enter!");
                   
                    Console.Read();

                    register = Wrapper.RegisterDevice();
                }



                //Get all your lights
                var Lights = Wrapper.ListLights();


            }

       




        }
    }
}
