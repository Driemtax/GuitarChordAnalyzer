using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ChordVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int StringCount = 6;
        private const int FretCount = 22;

        public MainWindow()
        {
            InitializeComponent();
            DrawFretboard();
            DrawNote(3, 2, "C", Brushes.Blue);
        }

        private void StartRecording_Click(object sender, RoutedEventArgs e)
        {
            // Start recording audio
        }

        private void StopRecording_Click(object sender, RoutedEventArgs e)
        {
            // Stop recording audio
        }

        private void DrawFretboard()
        {
            double canvasWidth = FretboardCanvas.ActualWidth > 0 ? FretboardCanvas.ActualWidth : 1200;
            double canvasHeight = FretboardCanvas.ActualHeight > 0 ? FretboardCanvas.ActualHeight : 600;

            double stringSpacing = canvasHeight / (StringCount + 1);
            double fretSpacing = canvasWidth / (FretCount + 2);

            // paint strings
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

                // label strings
                TextBlock stringLabel = new TextBlock
                {
                    Text = GetStringLabel(i),
                    FontSize = 14,
                    Foreground = Brushes.Black
                };
                Canvas.SetLeft(stringLabel, 5); // margin left
                Canvas.SetTop(stringLabel, y - 10); // vertical allignment
                FretboardCanvas.Children.Add(stringLabel);
            }

            // draw frets
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

                // label frets
                TextBlock fretLabel = new TextBlock
                {
                    Text = i.ToString(),
                    FontSize = 14,
                    Foreground = Brushes.Black
                };
                Canvas.SetLeft(fretLabel, x - 5); // center
                Canvas.SetTop(fretLabel, canvasHeight - stringSpacing + 10); // under the line
                FretboardCanvas.Children.Add(fretLabel);
            }
        }

        private string GetStringLabel(int index)
        {
            // Standard Gitarrenstimmung: E, A, D, G, B, E
            string[] labels = { "E", "A", "D", "G", "B", "E" };
            return labels[index];
        }

        private void DrawNote(int fret, int stringNumber, string note, Brush color)
        {
            double canvasWidth = FretboardCanvas.ActualWidth > 0 ? FretboardCanvas.ActualWidth : 1200;
            double canvasHeight = FretboardCanvas.ActualHeight > 0 ? FretboardCanvas.ActualHeight : 600;

            double stringSpacing = canvasHeight / (StringCount + 1);
            double fretSpacing = canvasWidth / (FretCount + 1);

            // Berechne Position der Note
            double x = fretSpacing * (fret + 1) - fretSpacing / 2;
            double y = stringSpacing * stringNumber;

            // Note als Kreis
            Ellipse noteCircle = new Ellipse
            {
                Width = 30,
                Height = 30,
                Fill = color
            };

            // Text in der Note
            TextBlock noteText = new TextBlock
            {
                Text = note,
                FontSize = 14,
                Foreground = Brushes.White,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Gruppiere Kreis und Text
            Canvas.SetLeft(noteCircle, x - 15);
            Canvas.SetTop(noteCircle, y - 15);
            Canvas.SetLeft(noteText, x - 10);
            Canvas.SetTop(noteText, y - 10);

            FretboardCanvas.Children.Add(noteCircle);
            FretboardCanvas.Children.Add(noteText);
        }

    }
}
