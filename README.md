# GlowSharp

GlowSharp is an inofficial and incomplete C# API Wrapper for the Phillips Hue API.

## Installation

You need the Visual Studio 2019 Community Edition or newer to open and execute the "Examples/Hello World/HelloWorld/HelloWorld.sln" file. 

Otherwise you're able to create a new project and inlude the "Source/GlowSharpLib.sln" as a Library. 

## Usage

```csharp
GlowSharp Wrapper = new GlowSharp();

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
    
    //Get all lights
    var Lights = Wrapper.ListLights();
}

                
```
