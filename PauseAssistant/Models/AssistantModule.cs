using BeatSaberMarkupLanguage.Attributes;

namespace PauseAssistant.Models
{
    public abstract class AssistantModule
    {
        [UIValue("name")]
        public abstract string Name { get; }

        [UIValue("is-slider")]
        public abstract bool IsSlider { get; }
    }
}