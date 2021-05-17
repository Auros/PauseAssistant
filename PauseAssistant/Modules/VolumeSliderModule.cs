using PauseAssistant.Models;

namespace PauseAssistant.Modules
{
    internal class VolumeSliderModule : SliderModule
    {
        public override string Name => "Volume";

        private float _value = 1f;
        public override float Value
        {
            get => _value;
            set
            {
                _value = value;
                System.Console.WriteLine(value);
            }
        }

        public override string Format(float value)
        {
            return value.ToString("P0");
        }

        public override float Minimum => 0;
        public override float Maximum => 1;

    }
}