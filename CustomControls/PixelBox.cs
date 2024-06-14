using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Flappy_Bird_Windows.CustomControls;

[ToolboxItem(true)]
public sealed class PixelBox : PictureBox
{
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        base.OnPaint(e);
    }
}
