using System;

public class Grayscale{
    public byte[] Encode(byte[] pixels, int width, int height)
    {
        //Output byte array
        int _metaDataLength = 2;
        byte[] _data = new byte[_metaDataLength + (width * height)];
        
        //Set width & height (meta data)
        _data[0] = (byte)width;
        _data[1] = (byte)height;

        //Set color
        for (int i = 0; i < width * height; ++i)
        {
            //Encode for grayscale display (255 shades)
            _data[i + _metaDataLength] = (byte)((pixels[i * 4] + pixels[i * 4 + 1] + pixels[i * 4 + 2]) / 3);
        }

        return _data;
    }

    //Function for decoding back from encoded data
    public DecodeResult Decode(byte[] data)
    {
        int _width = data[0];
        int _height = data[1];

        //create BGRA pixel array
        byte[] _pixels = new byte[_width * _height * 4];

        //Set pixels
        for (int i = 0; i < _width * _height; ++i)
        {
            _pixels[i*4] = data[2 + i];
            _pixels[i*4+1] = data[2 + i];
            _pixels[i*4+2] = data[2 + i];
            _pixels[i*4+3] = 0xFF; //Full alpha
        }

        //Create result container
        DecodeResult _result = new DecodeResult();
        _result.pixels = _pixels;
        _result.width = _width;
        _result.height = _height;

        return _result;
    }
}
