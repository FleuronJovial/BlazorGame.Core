using BlazorGame.Core.Components;

namespace BlazorGame.Core.Exceptions
{
    public class ComponentNotFoundException<TC> : Exception where TC : IComponent
    {
        public ComponentNotFoundException() : base($"{typeof(TC).Name} not found on owner")
        {
        }
    }
}
