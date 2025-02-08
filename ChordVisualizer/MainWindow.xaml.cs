using System.Windows;

namespace ChordVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartRecording_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recording started!");
            // TODO: Aufnahme-Logik hier einfügen
        }

        private void StopRecording_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Recording stopped!");
            // TODO: Aufnahme-Stop-Logik hier einfügen
        }
    }
}
