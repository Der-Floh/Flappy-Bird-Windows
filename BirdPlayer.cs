namespace Flappy_Bird_Windows;

public sealed class BirdPlayer
{
    public Bitmap? UpFlapImage { get; private set; }
    public Bitmap? MidFlapImage { get; private set; }
    public Bitmap? DownFlapImage { get; private set; }
    public Icon? Icon { get; private set; }
    private readonly string _upFlapFileName;
    private readonly string _midFlapFileName;
    private readonly string _downFlapFileName;
    private readonly string _iconFileName;

    public BirdPlayer(Color playerColor)
    {
        _upFlapFileName = playerColor.Name.ToLower() + "bird_upflap";
        _midFlapFileName = playerColor.Name.ToLower() + "bird_midflap";
        _downFlapFileName = playerColor.Name.ToLower() + "bird_downflap";
        _iconFileName = playerColor.Name.ToLower() + "bird_icon";
        UpFlapImage = Properties.Resources.ResourceManager.GetObject(_upFlapFileName) as Bitmap;
        MidFlapImage = Properties.Resources.ResourceManager.GetObject(_midFlapFileName) as Bitmap;
        DownFlapImage = Properties.Resources.ResourceManager.GetObject(_downFlapFileName) as Bitmap;
        Icon = Properties.Resources.ResourceManager.GetObject(_iconFileName) as Icon;
    }
}
