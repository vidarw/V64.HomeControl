using System;
using System.Collections.Generic;
using V64.HomeControl.Serial.Interfaces;

namespace V64.HomeControl.Serial.Commands.Rotel_RSP1069
{
    public class CommandsZone1 : ICommands
    {
        //private byte[] _core = {0xfe, 0x03, 0xa2, 0x14, 0x00, 0x00};

        private string _name;
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name)) {
					_name = "Main Zone";
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
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x4b, 0x04 };
        }

        public byte[] PowerOff()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x4a, 0x03 };
        }

        public byte[] PowerToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x0a, 0xc3 };
        }

        public byte[] MuteOn()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x6c, 0x25 };
        }

        public byte[] MuteOff()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x6d, 0x26 };
        }

        public byte[] MuteToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x1e, 0xd7 };
        }

        public byte[] VolumeDirect(int amount)
        {
            if (amount < 0 || amount > 100)
            {
                amount = 50;
            }

            byte[] cmd = { 0xfe, 0x03, 0xa2, 0x30, 0x30, 0x00 };

            cmd[4] = (byte)amount;
            cmd[5] = (byte)(cmd[1] + cmd[2] + cmd[3] + cmd[4]);

            if (cmd[5] == 0xfd)
            {
                cmd = new byte[] {cmd[1], cmd[2], cmd[3], cmd[4], 0xfd, 0x00};
            }

            if (cmd[5] == 0xfe)
            {
                cmd = new byte[] { cmd[0], cmd[1], cmd[2], cmd[3], cmd[4], 0xfd, 0x01 };
            }

            return cmd;
        }

        public byte[] VolumeUp()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x00, 0xb9 };
        }

        public byte[] VolumeDown()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x01, 0xba };
        }

        private Dictionary<string, byte[]> _source;
        public Dictionary<string, byte[]> Source
        {
            get
            {
                return _source ?? (_source = new Dictionary<string, byte[]>
                                                 {
                                                     {"CD", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x02, 0xbb }},
                                                     {"Tuner", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x03, 0xbc }},
                                                     {"Tape", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x04, 0xbd }},
                                                     {"Video 1", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x05, 0xbe }},
                                                     {"Video 2", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x06, 0xbf }},
                                                     {"Video 3", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x07, 0xc0 }},
                                                     {"Video 4", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x08, 0xc1 }},
                                                     {"Video 5", new byte[] { 0xfe, 0x03, 0xa2, 0x14, 0x09, 0xc2 }}
                                                 });
            }
        }
		
		private Dictionary<string, byte[]> _recordSource;
        public Dictionary<string, byte[]> RecordSource
        {
            get
            {
                return _recordSource ?? (_recordSource = new Dictionary<string, byte[]>
                                                 {
                                                     {"CD", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x02, 0xbc }},
                                                     {"Tuner", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x03, 0xbd }},
                                                     {"Tape", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x04, 0xbe }},
                                                     {"Video 1", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x05, 0xbf }},
                                                     {"Video 2", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x06, 0xc0 }},
                                                     {"Video 3", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x07, 0xc1 }},
                                                     {"Video 4", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x08, 0xc2 }},
                                                     {"Video 5", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x09, 0xc3 }},
													 {"Main Zone", new byte[] { 0xfe, 0x03, 0xa2, 0x15, 0x6b, 0x25 }}
                                                 });
            }
        }

        public byte[] PartyModeToggle()
        {
            return new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x6e, 0x23 };
        }


		private Dictionary<string, byte[]> _surroundMode;
        public Dictionary<string, byte[]> SurroundMode
        {
            get
            {
                return _surroundMode ?? (_surroundMode = new Dictionary<string, byte[]>
                                                 {
                                                     {"Stereo", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x11, 0xc6 }},
                                                     {"5 Channel Stereo", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x5b, 0x10 }},
                                                     {"7 Channel Stereo", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x5c, 0x11 }},
                                                     {"DSP: Music 1", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x57, 0x0c }},
                                                     {"DSP: Music 2", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x58, 0x0d }},
													 {"DSP: Music 3", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x59, 0x0e }},
													 {"DSP: Music 4", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x5a, 0x0f }},
									   				 {"Dolby 3 Stereo", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x12, 0xc7 }},
                                                     {"Dolby Pro Logic", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x13, 0xc8 }}
													 //{"Dolby PLII Cinema", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x08, 0xc2 }},
                                                     //{"Dolby PLII Music", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x08, 0xc2 }},
                                                     //{"Dolby PLII Game", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x09, 0xc3 }},
													 //{"dts Neo:6 Cinema", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x6b, 0x25 }},
													 //{"dts Neo:6 Music", new byte[] { 0xfe, 0x03, 0xa2, 0x10, 0x6b, 0x25 }}	
                                                 });
            }
        }

    }
}
