using BlazorGame.Core.Models;

namespace BlazorGame.Core.Interfaces
{
    public interface IComponent
    {
        ValueTask Update(GameContext game);

        GameObject Owner { get; }
    }
}
