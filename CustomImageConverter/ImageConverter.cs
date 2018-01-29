using System;
using System.Drawing;
using System.Drawing.Imaging;
using CSScriptLibrary;

//Interface for Image Converter Script
public interface IImageConverterScript
{
    byte[] Encode(byte[] pixels, int width, int height);
    DecodeResult Decode(byte[] data);
}
public class DecodeResult{
    public byte[] pixels;
    public int width;
    public int height;
}

//Image converter class for handling bitmap data and converter scripts
public class ImageConverter
{
    Bitmap _Source = null;
    public Bitmap Source
    {
        get
        {
            return _Source;
        }
        set
        {
            //If bitmap is locked, unlock it before changing to a new one
            if (bitmapData != null)
            {
                UnlockBits();
            }
            _Source = value;
        }
    }
    public string converterScriptName;

    IntPtr Iptr = IntPtr.Zero;
    BitmapData bitmapData = null;

    public byte[] Pixels { get; set; }
    public int Depth { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public ImageConverter()
	{
	}

    public ImageConverter(Bitmap source)
    {
        this.Source = source;
    }

    /// <summary>
    /// Lock bitmap data
    /// </summary>
    public void LockBits()
    {
        //Do nothing if there already is bitmap data
        if (bitmapData != null)
            return;

        try
        {
            // Get width and height of bitmap
            Width = Source.Width;
            Height = Source.Height;

            // get total locked pixels count
            int PixelCount = Width * Height;

            // Create rectangle to lock
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            // get source bitmap pixel format size
            Depth = System.Drawing.Bitmap.GetPixelFormatSize(Source.PixelFormat);

            // Check if bpp (Bits Per Pixel) is 8, 24, or 32
            if (Depth != 8 && Depth != 24 && Depth != 32)
            {
                throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
            }

            // Lock bitmap and return bitmap data
            bitmapData = Source.LockBits(rect, ImageLockMode.ReadWrite,
                                         Source.PixelFormat);

            // create byte array to copy pixel values
            int step = Depth / 8;
            Pixels = new byte[PixelCount * step];
            Iptr = bitmapData.Scan0;

            // Copy data from pointer to array
            System.Runtime.InteropServices.Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Unlock bitmap data
    /// </summary>
    public void UnlockBits(bool writeBack = false)
    {
        //Do nothing if there is no bitmapData
        if (bitmapData == null)
            return;

        try
        {
            if (writeBack)
            {
                // Copy data from byte array to pointer
                System.Runtime.InteropServices.Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
            }

            // Unlock bitmap data
            Source.UnlockBits(bitmapData);

            bitmapData = null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Get the color of the specified pixel
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Color GetPixel(int x, int y)
    {
        if (bitmapData == null)
            return Color.Empty;

        Color clr = Color.Empty;

        // Get color components count
        int cCount = Depth / 8;

        // Get start index of the specified pixel
        int i = ((y * Width) + x) * cCount;

        if (i > Pixels.Length - cCount)
            throw new IndexOutOfRangeException();

        if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
        {
            byte b = Pixels[i];
            byte g = Pixels[i + 1];
            byte r = Pixels[i + 2];
            byte a = Pixels[i + 3]; // a
            clr = Color.FromArgb(a, r, g, b);
        }
        if (Depth == 24) // For 24 bpp get Red, Green and Blue
        {
            byte b = Pixels[i];
            byte g = Pixels[i + 1];
            byte r = Pixels[i + 2];
            clr = Color.FromArgb(r, g, b);
        }
        if (Depth == 8)
        // For 8 bpp get color value (Red, Green and Blue values are the same)
        {
            byte c = Pixels[i];
            clr = Color.FromArgb(c, c, c);
        }
        return clr;
    }

    /// <summary>
    /// Set the color of the specified pixel
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    public void SetPixel(int x, int y, Color color)
    {
        if (bitmapData == null)
            return;

        // Get color components count
        int cCount = Depth / 8;

        // Get start index of the specified pixel
        int i = ((y * Width) + x) * cCount;

        if (Depth == 32) // For 32 bpp set Red, Green, Blue and Alpha
        {
            Pixels[i] = color.B;
            Pixels[i + 1] = color.G;
            Pixels[i + 2] = color.R;
            Pixels[i + 3] = color.A;
        }
        if (Depth == 24) // For 24 bpp set Red, Green and Blue
        {
            Pixels[i] = color.B;
            Pixels[i + 1] = color.G;
            Pixels[i + 2] = color.R;
        }
        if (Depth == 8)
        // For 8 bpp set color value (Red, Green and Blue values are the same)
        {
            Pixels[i] = color.B;
        }
    }

    /// <summary>
    /// Load the converter script
    /// </summary>
    /// <returns></returns>
    IImageConverterScript LoadScript()
    {
        try
        {
           return CSScript.Evaluator.LoadFile<IImageConverterScript>("./ConverterScripts/" + converterScriptName);
        }
        catch (Exception error)
        {
            System.Windows.Forms.MessageBox.Show(" Error while loading " + converterScriptName + " : \n" + error.Message,
                "Error in " + converterScriptName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            return null;
        }
    }


    /// <summary>
    /// Encodes the source bitmap.
    /// </summary>
    /// <returns>encoded bitmap data as byte array</returns>
    public byte[] Encode()
    {
        //If bitmap is not locked yet, lock it
        if (bitmapData == null)
        {
            LockBits();
        }

        byte[] _data = RunEncodingScript();

        //Unlock bitmap
        UnlockBits();

        //Return final byte array
        return _data;
    }

    byte[] RunEncodingScript()
    {
        if (string.IsNullOrEmpty(converterScriptName))
        {
            Console.WriteLine("No converter script set!");
            return null;
        }

        //Load converter script
        IImageConverterScript script = LoadScript();

        //Encode image using converter script
        try
        {
            return script.Encode(Pixels, Width, Height);
        }
        catch (Exception error)
        {
            System.Windows.Forms.MessageBox.Show("Could not encode image : \n" + error.Message,
                converterScriptName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            return null;
        }
    }

    /// <summary>
    /// Decode data. Save result in this.source
    /// </summary>
    /// <param name="inData"></param>
    /// <returns></returns>
    public void Decode(byte[] inData)
    {
        DecodeResult _result = RunDecodingScript(inData);
        if (_result == null)
            return;

        UnlockBits();

        if(this.Source != null)
            this.Source.Dispose();
        this.Source = new Bitmap(_result.width, _result.height);

        LockBits();

        Pixels = _result.pixels;

        UnlockBits(true);
    }

    public DecodeResult RunDecodingScript(byte[] inData)
    {
        if (string.IsNullOrEmpty(converterScriptName))
        {
            Console.WriteLine("No converter script set!");
            return null;
        }

        //Load converter script
        IImageConverterScript script = LoadScript();
        if (script == null)
            return null;

        //Decode image using converter script
        try
        {
            return script.Decode(inData);
        }
        catch (Exception error)
        {
            System.Windows.Forms.MessageBox.Show("Could not decode image : \n" + error.Message,
                converterScriptName, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            return null;
        }
    }
}
