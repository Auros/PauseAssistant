using BeatSaberMarkupLanguage.Attributes;

namespace PauseAssistant.Models
{
    public abstract class BoolModule : AssistantModule
    {
        [UIValue("value")]
        public abstract bool Value { get; set; }

        [UIAction("formatter")]
        public virtual string Format(bool value)
        {
            return value.ToString();
        }

        public override bool IsSlider => false;
        public override bool IsBool => true;
    }
}