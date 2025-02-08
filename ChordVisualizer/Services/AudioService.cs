using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ChordVisualizer.Services
{
    public class AudioService
    {
        private WaveInEvent _waveIn;
        private WaveFileWriter _writer;
        private string _outputFilePath = "..\\..\\..\\recorded_audio.wav";

        public List<string> GetAudioDevices()
        {
            List<string> devices = new();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                devices.Add(WaveIn.GetCapabilities(i).ProductName);
            }

            return devices;
        }

        public void StartRecording()
        {
            _waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 1) // 44.1kHz, 16-Bit, Mono
            };

            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.StartRecording();
        }

        public void StartRecording(string deviceName)
        {
            int deviceIndex = GetDeviceIndex(deviceName);
            
            _waveIn = new WaveInEvent
            {
                DeviceNumber = deviceIndex,
                WaveFormat = new WaveFormat(44100, 1)
            };

            _waveIn.DataAvailable += (s, e) => _writer.Write(e.Buffer, 0, e.BytesRecorded);
            _writer = new WaveFileWriter(_outputFilePath, _waveIn.WaveFormat);
            _waveIn.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            // process pcm data here
        }

        public void StopRecording()
        {
            _waveIn?.StopRecording();
            _waveIn?.Dispose();
            _writer?.Dispose();
            _waveIn = null;
        }

        public void PlayRecording()
        {
            var player = new WaveOutEvent();
            var reader = new AudioFileReader(_outputFilePath);
            player.Init(reader);
            player.Play();
        }

        private int GetDeviceIndex(string deviceName)
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                if (WaveIn.GetCapabilities(i).ProductName == deviceName)
                {
                    return i;
                }
            }

            return 0; // default device
        }
    }
}
