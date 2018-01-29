# CustomImageConverter
A super simple (read: hacky and ugly) custom image converter, which uses user created C# scripts to encode/decode images.

Comes with examples to convert images to imagecontroller formats so they can directly be pushed to the controller:
* color565 for ST7735, ILI9341, ILI9325, ILI9328. Should also work with other controllers that use the same format.
* grayscale
* monochrome

Also included: A hacked-in monochrome dithering filter to get that HD graphics to your monochrome display ...
