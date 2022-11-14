using BlazorGame.Core.Interfaces;
using BlazorGame.Core.Models;

namespace BlazorGame.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        protected BaseComponent(GameObject owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        //TODO: add an OnStart method

        public virtual async ValueTask Update(GameContext game)
        {
        }

        public GameObject Owner { get; }
    }
}