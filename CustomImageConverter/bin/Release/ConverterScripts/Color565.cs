//Converter for ST7735 and other Color565 devices. Should also work with ILI9341, ILI9325, ILI9328 and others. Just check if the color encoding below fits your display chip.

using System;

public class Color565
{
    readonly string fileEnding = "565";

    public string FileEnding() {
        return fileEnding;
    }

    public byte[] Encode(byte[] pixels, int width, int height)
    {
        //Output byte array
        int _metaDataLength = 2;
        byte[] _data = new byte[_metaDataLength + (width * height * 2)];

        
        //Set width & height (meta data)
        _data[0] = (byte)width;
        _data[1] = (byte)height;

        //Set color
        for (int i = 0; i < width * height; ++i)
        {
            //Encode for ST7735 / ILI9341
            // ((red & 0xF8) << 8) | ((green & 0xFC) << 3) | (blue >> 3);
            int _c = ((pixels[(i * 4) + 2] & 0xF8) << 8) | ((pixels[(i * 4) + 1] & 0xFC) << 3) | (pixels[(i * 4)] >> 3);
	    //Full transparent alpha -> make it black
	    if(pixels[(i*4)+3] == 0) _c = 0;

            //Convert to bytes
            //byte[] intBytes = BitConverter.GetBytes(_c);
            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(intBytes);

            //Set output data
            //_data[(i * 2) + 2] = intBytes[2];// (byte)(_c);
            //_data[(i * 2) + 3] = intBytes[3];// (byte)(_c >> 8);

            _data[(i * 2) + _metaDataLength] = (byte)_c;
            _data[(i * 2) + _metaDataLength + 1] = (byte)(_c >> 8);
        }

        return _data;
    }

    //Dummy Decoder function
    public DecodeResult Decode(byte[] data)
    {
        return null;
    }
}
