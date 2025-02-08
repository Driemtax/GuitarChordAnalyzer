using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ChordVisualizer.Views
{
    public partial class FretboardView : UserControl
    {
        private const int StringCount = 6;
        private const int FretCount = 22;

        public FretboardView()
        {
            InitializeComponent();
            DrawFretboard();
        }

        private void DrawFretboard()
        {
            double canvasWidth = FretboardCanvas.ActualWidth > 0 ? FretboardCanvas.ActualWidth : 1200;
            double canvasHeight = FretboardCanvas.ActualHeight > 0 ? FretboardCanvas.ActualHeight : 600;

            double stringSpacing = canvasHeight / (StringCount + 1);
            double fretSpacing = canvasWidth / (FretCount + 2);

            // Gitarrensaiten zeichnen
            for (int i = 0; i < StringCount; i++)
            {
                double y = stringSpacing * (i + 1);
                Line stringLine = new Line
                {
                    X1 = fretSpacing,
                    Y1 = y,
                    X2 = canvasWidth - fretSpacing,
                    Y2 = y,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                FretboardCanvas.Children.Add(stringLine);
            }

            // Bünde zeichnen
            for (int i = 0; i <= FretCount; i++)
            {
                double x = fretSpacing * i + fretSpacing;
                Line fretLine = new Line
                {
                    X1 = x,
                    Y1 = stringSpacing,
                    X2 = x,
                    Y2 = canvasHeight - stringSpacing,
                    Stroke = Brushes.Gray,
                    StrokeThickness = 2
                };
                FretboardCanvas.Children.Add(fretLine);
            }
        }
    }
}
