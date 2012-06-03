namespace V64.HomeControl.Serial.Console
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Too few arguments.");
                Console.WriteLine("Usage: homecontrol.exe portname command value");
            }

            try
            {
                var dev = new Devices.Rotel_RSP1069();

                dev.SerialPort.PortName = args[0];
                dev.SerialPort.ReadBufferSize = 52;

                var command = args[1];
                switch (command)
                {
                    case "vol":
                        dev.RunCommand(dev.Zones[0].VolumeDirect(int.Parse(args[3])));
                        break;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Program error");
            }
        }
		
		
    }
}
