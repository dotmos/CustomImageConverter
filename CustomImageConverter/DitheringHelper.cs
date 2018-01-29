// Dithering helper from http://www.codeproject.com/Articles/1001088/Dithering-an-Image-Using-the-Floyd-Steinberg-Algor
// https://github.com/cyotek/Dithering

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace CustomImageConverter
{
    class DitheringHelper
    {
        public Bitmap ApplyDithering(Bitmap _image)
        {
            Bitmap image;
            ArgbColor[] originalData;
            Size size;
            IErrorDiffusion dither;

            image = _image;
            size = image.Size;

            originalData = image.GetPixelsFrom32BitArgbImage();

            //Set dithering algorithm
            dither = new FloydSteinbergDithering();

            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    int index;
                    ArgbColor current;
                    ArgbColor transformed;

                    index = row * size.Width + col;

                    current = originalData[index];

                    // transform the pixel - normally this would be some form of color
                    // reduction. For this sample it's simple threshold based
                    // monochrome conversion
                    transformed = TransformPixel(current);
                    originalData[index] = transformed;

                    // apply a dither algorithm to this pixel
                    if (dither != null)
                    {
                        dither.Diffuse(originalData, current, transformed, col, row, size.Width, size.Height);
                    }
                }
            }

            return originalData.ToBitmap(size);
        }

        private ArgbColor TransformPixel(ArgbColor pixel)
        {
            byte gray;

            gray = (byte)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);

            /*
             * I'm leaving the alpha channel untouched instead of making it fully opaque
             * otherwise the transparent areas become fully black, and I was getting annoyed
             * by this when testing images with large swathes of transparency!
             */

            return gray < (byte)128 ? new ArgbColor(pixel.A, 0, 0, 0) : new ArgbColor(pixel.A, 255, 255, 255);
        }
    }


    public sealed class FloydSteinbergDithering : ErrorDiffusionDithering
    {
        #region Constructors

        public FloydSteinbergDithering()
            : base(new byte[,]
             {
               {
                 0, 0, 7
               },
               {
                 3, 5, 1
               }
             }, 4, true)
        { }

        #endregion
    }

    public sealed class Sierra2Dithering : ErrorDiffusionDithering
    {
        #region Constructors

        public Sierra2Dithering()
            : base(new byte[,]
             {
               {
                 0, 0, 0, 4, 3
               },
               {
                 1, 2, 3, 2, 1
               }
             }, 4, true)
        { }

        #endregion
    }

    public sealed class BurksDithering : ErrorDiffusionDithering
    {
        #region Constructors

        public BurksDithering()
            : base(new byte[,]
             {
               {
                 0, 0, 0, 8, 4
               },
               {
                 2, 4, 8, 4, 2
               }
             }, 5, true)
        { }

        #endregion
    }

    public sealed class AtkinsonDithering : ErrorDiffusionDithering
    {
        #region Constructors

        public AtkinsonDithering()
            : base(new byte[,]
             {
               {
                 0, 0, 1, 1
               },
               {
                 1, 1, 1, 0
               },
               {
                 0, 1, 0, 0
               }
             }, 3, true)
        { }

        #endregion
    }

    public sealed class JarvisJudiceNinkeDithering : ErrorDiffusionDithering
    {
        #region Constructors

        public JarvisJudiceNinkeDithering()
            : base(new byte[,]
             {
               {
                 0, 0, 0, 7, 5
               },
               {
                 3, 5, 7, 5, 3
               },
               {
                 1, 3, 5, 3, 1
               }
             }, 48, false)
        { }

        #endregion
    }

    public sealed class SierraLiteDithering : ErrorDiffusionDithering
    {
        #region Constructors

        public SierraLiteDithering()
            : base(new byte[,]
             {
               {
                 0, 0, 2
               },
               {
                 1, 1, 0
               }
             }, 2, true)
        { }

        #endregion
    }


   



    public abstract class ErrorDiffusionDithering : IErrorDiffusion
    {
        #region Constants

        private readonly byte _divisor;

        private readonly byte[,] _matrix;

        private readonly byte _matrixHeight;

        private readonly byte _matrixWidth;

        private readonly byte _startingOffset;

        private readonly bool _useShifting;

        #endregion

        #region Constructors

        protected ErrorDiffusionDithering(byte[,] matrix, byte divisor, bool useShifting)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            if (matrix.Length == 0)
            {
                throw new ArgumentException("Matrix is empty.", "matrix");
            }

            _matrix = matrix;
            _matrixWidth = (byte)(matrix.GetUpperBound(1) + 1);
            _matrixHeight = (byte)(matrix.GetUpperBound(0) + 1);
            _divisor = divisor;
            _useShifting = useShifting;

            for (int i = 0; i < _matrixWidth; i++)
            {
                if (matrix[0, i] != 0)
                {
                    _startingOffset = (byte)(i - 1);
                    break;
                }
            }
        }

        #endregion

        #region IErrorDiffusion Interface

        void IErrorDiffusion.Diffuse(ArgbColor[] data, ArgbColor original, ArgbColor transformed, int x, int y, int width, int height)
        {
            int redError;
            int blueError;
            int greenError;

            redError = original.R - transformed.R;
            blueError = original.G - transformed.G;
            greenError = original.B - transformed.B;

            for (int row = 0; row < _matrixHeight; row++)
            {
                int offsetY;

                offsetY = y + row;

                for (int col = 0; col < _matrixWidth; col++)
                {
                    int coefficient;
                    int offsetX;

                    coefficient = _matrix[row, col];
                    offsetX = x + (col - _startingOffset);

                    if (coefficient != 0 && offsetX > 0 && offsetX < width && offsetY > 0 && offsetY < height)
                    {
                        ArgbColor offsetPixel;
                        int offsetIndex;
                        int newR;
                        int newG;
                        int newB;
                        byte r;
                        byte g;
                        byte b;

                        offsetIndex = offsetY * width + offsetX;
                        offsetPixel = data[offsetIndex];

                        // if the UseShifting property is set, then bit shift the values by the specified
                        // divisor as this is faster than integer division. Otherwise, use integer division

                        if (_useShifting)
                        {
                            newR = (redError * coefficient) >> _divisor;
                            newG = (greenError * coefficient) >> _divisor;
                            newB = (blueError * coefficient) >> _divisor;
                        }
                        else
                        {
                            newR = (redError * coefficient) / _divisor;
                            newG = (greenError * coefficient) / _divisor;
                            newB = (blueError * coefficient) / _divisor;
                        }

                        r = (offsetPixel.R + newR).ToByte();
                        g = (offsetPixel.G + newG).ToByte();
                        b = (offsetPixel.B + newB).ToByte();

                        data[offsetIndex] = ArgbColor.FromArgb(offsetPixel.A, r, g, b);
                    }
                }
            }
        }

        #endregion
    }





    public struct ArgbColor
    {
        /// <summary>
        /// Gets the blue component value of this <see cref="ArgbColor"/> structure.
        /// </summary>
        //[FieldOffset(0)]
        public byte B;

        /// <summary>
        /// Gets the green component value of this <see cref="ArgbColor"/> structure.
        /// </summary>
        //[FieldOffset(1)]
        public byte G;

        /// <summary>
        /// Gets the red component value of this <see cref="ArgbColor"/> structure.
        /// </summary>
        //[FieldOffset(2)]
        public byte R;

        /// <summary>
        /// Gets the alpha component value of this <see cref="ArgbColor"/> structure.
        /// </summary>
        //[FieldOffset(3)]
        public byte A;

        public ArgbColor(int alpha, int red, int green, int blue)
            : this()
        {
            A = (byte)alpha;
            R = (byte)red;
            G = (byte)green;
            B = (byte)blue;
        }

        internal static ArgbColor FromArgb(byte a, byte r, byte g, byte b)
        {
            return new ArgbColor(a, r, g, b);
        }
    }

    public interface IErrorDiffusion
    {
        #region Methods

        void Diffuse(ArgbColor[] data, ArgbColor original, ArgbColor transformed, int x, int y, int width, int height);

        #endregion
    }

    internal static class IntegerExtensions
    {
        #region Static Methods

        internal static byte ToByte(this int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 255)
            {
                value = 255;
            }

            return (byte)value;
        }

        #endregion
    }



    internal static class ImageUtilities
    {
        #region Static Methods

        public static Bitmap Copy(this Image image)
        {
            Bitmap copy;

            copy = new Bitmap(image.Size.Width, image.Size.Height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(copy))
            {
                g.Clear(Color.Transparent);
                g.PageUnit = GraphicsUnit.Pixel;
                g.DrawImage(image, new Rectangle(Point.Empty, image.Size));
            }

            return copy;
        }

        public static Bitmap ToBitmap(this ArgbColor[] data, Size size)
        {
            int height;
            int width;
            BitmapData bitmapData;
            Bitmap result;

            // Based on code from http://blog.biophysengr.net/2011/11/rapid-bitmap-access-using-unsafe-code.html

            result = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            width = result.Width;
            height = result.Height;

            // Lock the entire bitmap
            bitmapData = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            //Enter unsafe mode so that we can use pointers
            unsafe
            {
                ArgbColor* pixelPtr;

                // Get a pointer to the beginning of the pixel data region
                // The upper-left corner
                pixelPtr = (ArgbColor*)bitmapData.Scan0;

                // Iterate through rows and columns
                for (int row = 0; row < size.Height; row++)
                {
                    for (int col = 0; col < size.Width; col++)
                    {
                        int index;
                        ArgbColor color;

                        index = row * size.Width + col;
                        color = data[index];

                        // Set the pixel (fast!)
                        *pixelPtr = color;

                        // Update the pointer
                        pixelPtr++;
                    }
                }
            }

            // Unlock the bitmap
            result.UnlockBits(bitmapData);

            return result;
        }

        internal static ArgbColor[] GetPixelsFrom32BitArgbImage(this Bitmap bitmap)
        {
            int width;
            int height;
            BitmapData bitmapData;
            ArgbColor[] results;

            // NOTE: As the name should give a hint, it only supports 32bit ARGB images.
            // Don't rely on this for production, it needs expanding to support multiple other types

            width = bitmap.Width;
            height = bitmap.Height;
            results = new ArgbColor[width * height];
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                ArgbColor* pixel;

                pixel = (ArgbColor*)bitmapData.Scan0;

                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        results[row * width + col] = *pixel;

                        pixel++;
                    }
                }
            }

            bitmap.UnlockBits(bitmapData);

            return results;
        }

        #endregion
    }
}
