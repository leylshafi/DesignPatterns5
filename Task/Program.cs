public abstract class Remote
{
    protected IDevice Device { get; set; }
    public Remote(IDevice device)
    {
        Device=device;
    }
    public void togglePower()
    {
        if (Device.IsEnabled())
            Device.Disable();
        else 
            Device.Enable();
    }
    public void volumeDown()
    {
        int current = Device.GetVolume();
        Device.SetVolume(--current);
    }
    public void volumeUp()
    {
        int current = Device.GetVolume();
        Device.SetVolume(++current);
    }
    public void channelDown()
    {
        int current = Device.GetChannel();
        Device.SetChannel(--current);
    }
    public void channnelUp()
    {
        int current = Device.GetChannel();
        Device.SetChannel(++current);
    }
}

public class AdvancedRemote:Remote
{

    public AdvancedRemote(IDevice device) : base(device)
    {

    }

    public void Mute()
    {
        Device.SetVolume(0);
    }
}

public interface IDevice
{

    bool IsEnabled();
    int GetVolume();
    void SetVolume(int num);
    int GetChannel();
    void SetChannel(int num);
    void Enable();
    void Disable();
}

public class Radio : IDevice
{
    public bool IsEnable = false;
    public int Volume=0;
    public int Channel=0;

    public void Disable()
    {
        IsEnable = false;
    }

    public void Enable()
    {
        IsEnable = true;
    }

    public int GetChannel()
    {
       return Channel;
    }

    public int GetVolume()
    {
        return Volume;
    }

    public bool IsEnabled()
    {
       return IsEnable;
    }

    public void SetChannel(int num)
    {
        Channel = num;
    }

    public void SetVolume(int num)
    {
        Volume = num;
    }
    public override string ToString() =>
$"Device {nameof(Radio)},\n" +
$"Is Enabled - {IsEnable},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


public class TV : IDevice
{
    public bool IsEnable = false;
    public int Volume=0;
    public int Channel=0;

    public void Disable()
    {
        IsEnable = false;
    }

    public void Enable()
    {
        IsEnable = true;
    }

    public int GetChannel()
    {
        return Channel;
    }

    public int GetVolume()
    {
        return Volume;
    }

    public bool IsEnabled()
    {
        return IsEnable;
    }

    public void SetChannel(int num)
    {
        Channel = num;
    }

    public void SetVolume(int num)
    {
        Volume = num;
    }
    public override string ToString() =>
$"Device {nameof(TV)},\n" +
$"Is Enabled - {IsEnable},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


class Program
{
    static void Main()
    {
        IDevice device = new Radio();
        device.SetVolume(50);
        device.SetChannel(22);

        Remote remote = new AdvancedRemote(device);
        remote.channnelUp();
        remote.volumeDown();

        Console.WriteLine(device);


        device = new TV();
        device.SetVolume(30);
        device.SetChannel(45);

        remote = new AdvancedRemote(device);
        remote.togglePower();
        remote.volumeUp();
        remote.channnelUp();
        Console.WriteLine();
        Console.WriteLine(device);
    }
}
