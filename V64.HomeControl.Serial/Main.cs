using System;
using System.IO.Ports;

namespace V64.HomeControl.Serial
{
	class MainClass
	{	
		public static void Main (string[] args)
		{
            var dev = new Devices.Rotel_RSP1069();

            dev.SerialPort.PortName = "COM3";
            dev.SerialPort.ReadBufferSize = 52;
			
			dev.RunCommand(dev.Zones[0].VolumeDirect(66));
			
            dev.SerialPort.Open();
            dev.SerialPort.Close();
			
			/*
			var sp = new SerialPort()
                    {
                        BaudRate = 38400,
                        Parity = Parity.None,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Handshake = Handshake.None
                    };
			
			
			sp.PortName = args[1];
			var togglePower = new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x0a, 0xc3 };
			
			sp.Open();
            sp.Write(togglePower, 0, 6);
            sp.Close();
            */
		}
		
		
		
		
	
	
	}
}
