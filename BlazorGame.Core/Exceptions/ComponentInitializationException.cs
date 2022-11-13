using BlazorGame.Core.Interfaces;

namespace BlazorGame.Core.Exceptions
{
    public class ComponentInitializationException<TC> : Exception where TC : IComponent
    {
        public ComponentInitializationException() : base($"{typeof(TC).Name} contructor info not found")
        {
        }
    }
}
