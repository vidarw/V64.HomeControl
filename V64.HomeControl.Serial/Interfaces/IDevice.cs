using System.Collections.Generic;
using System.IO.Ports;

namespace V64.HomeControl.Serial.Interfaces
{
    interface IDevice
    {
        string Model { get; }
        string Vendor { get; }

        SerialPort SerialPort { get; set; }
		List<ICommands> Zones { get; set; }
		
		bool RunCommand(byte[] cmd);

    }
}
