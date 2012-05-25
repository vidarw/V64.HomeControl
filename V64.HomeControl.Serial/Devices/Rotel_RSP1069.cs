using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using V64.HomeControl.Serial.Commands.Rotel_RSP1069;
using V64.HomeControl.Serial.Interfaces;


namespace V64.HomeControl.Serial.Devices
{
    public class Rotel_RSP1069 : IDevice
    {

        public string Model
        {
            get { return "RSP-1069"; }
        }

        public string Vendor
        {
            get { return "Rotel"; }
        }

        private SerialPort _serialPort;
        public SerialPort SerialPort
        {
            get
            {
                if (_serialPort == null)
                {
                    _serialPort = new SerialPort()
                    {
                        BaudRate = 38400,
                        Parity = Parity.None,
                        DataBits = 8,
                        StopBits = StopBits.One,
                        Handshake = Handshake.None
                    };
                }
                return _serialPort;
            }
            set { _serialPort = value; }
        }

        private List<ICommands> _zones; 
        public List<ICommands> Zones
        {
            get
            {
                if (_zones == null)
                {
                    _zones = new List<ICommands>();
                    _zones.Add(new CommandsZone1());
                    _zones.Add(new CommandsZone2());
                    _zones.Add(new CommandsZone3());
                    _zones.Add(new CommandsZone4());
                }
                return _zones;
            }
            set { _zones = value; }
        }
		
		public bool RunCommand(byte[] cmd){
			
			this.SerialPort.Open();
            this.SerialPort.Write(cmd, 0, cmd.Length);
			this.SerialPort.Close();
			
			return false;
		}
    }
}
