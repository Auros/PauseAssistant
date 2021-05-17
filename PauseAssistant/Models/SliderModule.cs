using BeatSaberMarkupLanguage.Attributes;
using System;

namespace PauseAssistant.Models
{
    public abstract class SliderModule : AssistantModule
    {
        [UIValue("min")]
        public virtual float Minimum { get; }

        [UIValue("max")]
        public virtual float Maximum { get; }

        [UIValue("value")]
        public abstract float Value { get; set; }

        [UIAction("formatter")]
        public virtual string Format(float value)
        {
            return Math.Round(value, 2).ToString();
        }

        public override bool IsSlider => true;
    }
}