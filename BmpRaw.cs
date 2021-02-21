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
