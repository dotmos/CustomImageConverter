# CustomImageConverter
A super simple (read: hacky and ugly) custom image converter, which uses user created C# scripts to encode/decode images.


Comes with examples to convert images to imagecontroller formats so they can directly be pushed to the controller:
* color565 for ST7735, ILI9341, ILI9325, ILI9328. Should also work with other controllers that use the same format.
* grayscale
* monochrome

Also included: A hacked-in monochrome dithering filter to get that HD graphics to your monochrome display ...



Example encode/decode script for monochrome:
```csharp
public class Monochrome{
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
            if ((byte)(0.299f * pixels[i * 4 + 2] + 0.587f * pixels[i * 4 + 1] + 0.114f * pixels[i * 4]) >= 0x7F)
                _data[i + _metaDataLength] = 0xFF; //dot
            else
                _data[i + _metaDataLength] = 0x00; //no dot

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
```
