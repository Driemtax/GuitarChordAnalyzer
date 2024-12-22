using NAudio.Wave;

namespace ChordVisualizer.Services
{
    public class AudioService
    {
        private WaveInEvent waveIn;

        public void StartRecording()
        {
            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 1) // 44.1kHz, 16-Bit, Mono
            };

            waveIn.DataAvailable += OnDataAvailable;
            waveIn.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            // process pcm data here
        }

        public void StopRecording()
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();
            waveIn = null;
        }
    }
}
