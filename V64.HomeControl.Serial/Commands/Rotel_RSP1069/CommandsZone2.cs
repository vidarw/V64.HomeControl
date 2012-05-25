using System;
using System.Collections.Generic;
using V64.HomeControl.Serial.Interfaces;

namespace V64.HomeControl.Serial.Commands.Rotel_RSP1069
{
    public class CommandsZone2 : ICommands
    {
		private string _name;
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name)) {
					_name = "Zone 2";
				}
				return _name;
            }
			set
			{
				_name = value;
			}
        }

        public byte[] PowerOn()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x4b, 0x06 };
        }

        public byte[] PowerOff()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x4a, 0x05 };
        }

        public byte[] PowerToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x0a, 0xc5 };
        }

        public byte[] MuteOn()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x6c, 0x27 };
        }

        public byte[] MuteOff()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x6d, 0x28 };
        }

        public byte[] MuteToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x1e, 0xd9 };
        }

        public byte[] VolumeUp()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x00, 0xbb };
        }

        public byte[] VolumeDown()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x01, 0xbc };
        }
		
		private Dictionary<string, byte[]> _source;
        public Dictionary<string, byte[]> Source
        {
            get
            {
                return _source ?? (_source = new Dictionary<string, byte[]>
                                                 {
                                                     {"CD", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x02, 0xbd }},
                                                     {"Tuner", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x03, 0xbe }},
                                                     {"Tape", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x04, 0xbf }},
                                                     {"Video 1", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x05, 0xc0 }},
                                                     {"Video 2", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x06, 0xc1 }},
                                                     {"Video 3", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x07, 0xc2 }},
                                                     {"Video 4", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x08, 0xc3 }},
                                                     {"Video 5", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x09, 0xc4 }},
													 {"Main Zone", new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x6b, 0x26 }}
                                                 });
            }
        }

        public Dictionary<string, byte[]> RecordSource
        {
            get { throw new NotImplementedException("Not available"); }
        }

        public byte[] PartyModeToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x16, 0x6e, 0x29 };
        }


        public Dictionary<string, byte[]> SurroundMode
        {
            get { return new Dictionary<string, byte[]>(); }
        }


        public byte[] VolumeDirect(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
