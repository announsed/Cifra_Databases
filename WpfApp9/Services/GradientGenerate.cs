using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp9.Services
{
    internal static class GradientGenerate
    {
        private static LinearGradientBrush? _linerGradientBrush;
        private static GradientStopCollection? _gradientStopCollectionRed;
        private static GradientStopCollection GetRedGradientCollection() 
        {
            GradientStopCollection redGradientStopCollection = new();
            redGradientStopCollection.Add(new GradientStop(Colors.Black, 0.0));
            redGradientStopCollection.Add(new GradientStop(Colors.Red, 0.25));
            redGradientStopCollection.Add(new GradientStop(Colors.Black, 0.5));
            redGradientStopCollection.Add(new GradientStop(Colors.Red, 0.75));
            redGradientStopCollection.Add(new GradientStop(Colors.Black, 1.0));
            return redGradientStopCollection;
        }
        private static GradientStopCollection GetGreenGradientCollection() 
        {
            GradientStopCollection greenGradientStopCollection = new();
            greenGradientStopCollection.Add(new GradientStop(Colors.Black, 0.0));
            greenGradientStopCollection.Add(new GradientStop(Colors.Red, 0.25));
            greenGradientStopCollection.Add(new GradientStop(Colors.Black, 0.5));
            greenGradientStopCollection.Add(new GradientStop(Colors.Red, 0.75));
            greenGradientStopCollection.Add(new GradientStop(Colors.Black, 1.0));
            return greenGradientStopCollection;
        }
        public static LinearGradientBrush GetRedGradientBrush() 
        {
            _linerGradientBrush = new LinearGradientBrush(GetRedGradientCollection());
            return _linerGradientBrush;
        }

        public static LinearGradientBrush GetGreenGradientBrush()
        {
            _linerGradientBrush = new LinearGradientBrush(GetGreenGradientCollection());
            return _linerGradientBrush;
        }
    }
}
