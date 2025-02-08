using System.Collections.ObjectModel;
using System.Windows.Input;
using ChordVisualizer.Services;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace ChordVisualizer.ViewModels
{
    public class RecordingViewModel : BaseViewModel
    {
        private readonly AudioService _audioService;

        public ObservableCollection<string> AudioDevices { get; } = new();
        private string _selectedDevice;
        public string SelectedDevice
        {
            get => _selectedDevice;
            set { _selectedDevice = value; OnPropertyChanged(); }
        }

        private bool _isRecording;
        public bool IsRecording
        {
            get => _isRecording;
            set
            {
                _isRecording = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(CanStartRecording));
                //OnPropertyChanged(nameof(CanStopRecording));
            }
        }

        //public bool CanStartRecording => !IsRecording;
        //public bool CanStopRecording => IsRecording;

        public ICommand StartRecordingCommand { get; }
        public ICommand StopRecordingCommand { get; }
        public ICommand PlayRecordingCommand { get; } 

        public RecordingViewModel(AudioService audioService)
        {
            _audioService = audioService;

            StartRecordingCommand = new RelayCommand(StartRecording);
            StopRecordingCommand = new RelayCommand(StopRecording);
            PlayRecordingCommand = new RelayCommand(PlayRecording);

            LoadAudioDevices();
        }

        private void LoadAudioDevices()
        {
            var devices = _audioService.GetAudioDevices();
            foreach (var device in devices)
            {
                AudioDevices.Add(device);
            }

            SelectedDevice = AudioDevices.Count > 0 ? AudioDevices[0] : null;
        }

        private void StartRecording()
        {
            _audioService.StartRecording(SelectedDevice);
            IsRecording = true;
        }
        private void StopRecording()
        {
            _audioService.StopRecording();
            IsRecording = false;
        }
        private void PlayRecording()
        {
            _audioService.PlayRecording();
        }
    }
}
