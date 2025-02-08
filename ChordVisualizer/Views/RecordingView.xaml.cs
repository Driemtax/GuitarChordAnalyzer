using System.Windows.Controls;
using ChordVisualizer.ViewModels;

namespace ChordVisualizer.Views
{
    /// <summary>
    /// Interaction logic for RecordingView.xaml
    /// </summary>
    public partial class RecordingView : UserControl
    {
        public RecordingView()
        {
            InitializeComponent();
            DataContext = new RecordingViewModel(new Services.AudioService());
        }
    }
}
