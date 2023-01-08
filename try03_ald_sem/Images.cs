using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace try03_ald_sem
{
    public static class Images
    {
        public readonly static ImageSource Empty = LoadImage("Empty.png");
        public readonly static ImageSource Cross3_1110 = LoadImage("Cross3_1110.png");
        public readonly static ImageSource Cross3_0111 = LoadImage("Cross3_0111.png");
        public readonly static ImageSource Cross3_1011 = LoadImage("Cross3_1011.png");
        public readonly static ImageSource Cross3_1101 = LoadImage("Cross3_1101.png");
        public readonly static ImageSource Cross4 = LoadImage("Cross4.png");
        public readonly static ImageSource Curve_1100 = LoadImage("Curve_1100.png");
        public readonly static ImageSource Curve_0110 = LoadImage("Curve_0110.png");
        public readonly static ImageSource Curve_0011 = LoadImage("Curve_0011.png");
        public readonly static ImageSource Curve_1001 = LoadImage("Curve_1001.png");
        public readonly static ImageSource End_1000 = LoadImage("End_1000.png");
        public readonly static ImageSource End_0100 = LoadImage("End_0100.png");
        public readonly static ImageSource End_0010 = LoadImage("End_0010.png");
        public readonly static ImageSource End_0001 = LoadImage("End_0001.png");
        public readonly static ImageSource Straight_1010 = LoadImage("Straight_1010.png");
        public readonly static ImageSource Straight_0101 = LoadImage("Straight_0101.png");
        public readonly static ImageSource NotReady = LoadImage("NotReady.png");

        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));

        }
    }
}
