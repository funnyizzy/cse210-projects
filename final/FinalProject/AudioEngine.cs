using System;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

public class AudioEngine : IDisposable
{
    private WaveOutEvent _output;
    private MixingSampleProvider _mixer;

    private float _gain = 1.0f;

    public float Gain
    {
        get => _gain;
        set
        {
            if (value < 0f) value = 0f;
            _gain = value;
        }
    }

    public AudioEngine()
    {
        _output = new WaveOutEvent
        {
            DesiredLatency = 100
        };

        _mixer = new MixingSampleProvider(
            WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
        {
            ReadFully = true
        };

        _output.Init(_mixer);
        _output.Volume = 1.0f;
        _output.Play();
    }

    public void PlayFile(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
            return;

        var reader = new AudioFileReader(path);
        var gainProvider = new VolumeSampleProvider(reader.ToSampleProvider())
        {
            Volume = _gain
        };

        _mixer.AddMixerInput(gainProvider);
    }

    public void StopAll()
    {
        _output.Stop();

        _mixer = new MixingSampleProvider(
            WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))
        {
            ReadFully = true
        };

        _output.Init(_mixer);
        _output.Play();
    }

    public void Dispose()
    {
        _output?.Stop();
        _output?.Dispose();
    }
}
