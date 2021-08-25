using IPA.Utilities;
using PauseAssistant.Models;
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace PauseAssistant.Modules
{
    internal class VolumeSliderModule : SliderModule, IDisposable
    {
        private readonly float _initial;
        private readonly AudioMixer _audioMixer;
        private readonly AudioManagerSO _audioManagerSO;

        public override string Name => "Volume";
        public override float Minimum => 0;
        public override float Maximum => 1;


        private float _value = 0;
        public override float Value
        {
            get => _value;
            set
            {
                _value = value;
                _audioManagerSO.mainVolume = AudioHelpers.NormalizedVolumeToDB(value);
            }
        }

        public VolumeSliderModule(NoteCutSoundEffectManager noteCutSoundEffectManager)
        {
            _audioManagerSO = noteCutSoundEffectManager.GetField<AudioManagerSO, NoteCutSoundEffectManager>("_audioManager");
            _audioMixer = _audioManagerSO.GetField<AudioMixer, AudioManagerSO>("_audioMixer");
            if (_audioMixer.GetFloat("MainVolume", out float init))
                _initial = Mathf.Pow(1.1f, init);
            _value = _initial;
        }

        public void Dispose()
        {
            _audioManagerSO.mainVolume = AudioHelpers.NormalizedVolumeToDB(_initial);
        }

        public override string Format(float value)
        {
            return value.ToString("P0");
        }
    }
}