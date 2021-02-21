/*
This class allows to have a fast access to a bitmap. As a type argument, use any structure with the same size as the size of each pixel of your bitmap. Make sure to use
explicit kind of layout if working with a 3 or 6 byte picture.
*/

public unsafe class BmpRaw<T> : IDisposable where T : unmanaged
{
    private Bitmap bmp;
    private BitmapData data;
    public BmpRaw(Bitmap bmp, ImageLockMode mode = ImageLockMode.ReadWrite, PixelFormat format = PixelFormat.Format32bppArgb)
    {
        this.bmp = bmp;
        data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), mode, format);
    }

    public int Width => bmp.Width;
    public int Height => bmp.Height;
    public Bitmap Source => bmp;

    public T this[int x, int y]
    {
        get => *((T*)data.Scan0 + x + y * bmp.Width);
        set => *((T*)data.Scan0 + x + y * bmp.Width) = value;
    }

    public void Dispose()
    {
        bmp.UnlockBits(data);
    }

    public bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;
}


/* Formats */

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
struct Color8
{
    public byte V;
}

[StructLayout(LayoutKind.Sequential, Size = 2)]
struct Color16
{
    public ushort V;
}


[StructLayout(LayoutKind.Sequential, Size = 3)]
struct Color24RGB
{
    public byte R, G, B;
}


[StructLayout(LayoutKind.Sequential, Size = 4)]
struct Color32RGBA
{
    public byte R, G, B, A;
}

[StructLayout(LayoutKind.Sequential, Size = 6)]
struct Color48RGB
{
    public ushort R, G, B;
}

[StructLayout(LayoutKind.Sequential, Size = 8)]
struct Color64RGB
{
    public ushort R, G, B, A;
}
