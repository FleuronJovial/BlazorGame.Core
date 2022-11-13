using Blazor.Extensions.Canvas.Canvas2D;

namespace BlazorGame.Core
{
    public interface IRenderable
    {
        ValueTask Render(GameContext game, Canvas2DContext context);
    }
}
