using Blazor.Extensions.Canvas.Canvas2D;
using BlazorGame.Core.Models;

namespace BlazorGame.Core.Interfaces
{
    public interface IRenderable
    {
        ValueTask Render(GameContext game, Canvas2DContext context);
    }
}
