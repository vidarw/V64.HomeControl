using System.Collections.Generic;

namespace V64.HomeControl.Serial.Interfaces
{
    public interface ICommands
    {

        string Name { get; set; }

        byte[] PowerOn();
        byte[] PowerOff();
        byte[] PowerToggle();

        byte[] MuteOn();
        byte[] MuteOff();
        byte[] MuteToggle();

        byte[] VolumeUp();
        byte[] VolumeDown();
        byte[] VolumeDirect(int amount);

        Dictionary<string, byte[]> Source { get; }
        Dictionary<string, byte[]> RecordSource { get; }
        Dictionary<string, byte[]> SurroundMode { get; }

        byte[] PartyModeToggle();


    }
}
