namespace PauseAssistant.Models
{
    public abstract class SliderModule : IAssistantModule
    {
        public abstract string Name { get; }
        public virtual float Minimum { get; }
        public virtual float Maximum { get; }
        public abstract float Value { get; set; }
    }
}