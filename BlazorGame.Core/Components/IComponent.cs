using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGame.Core.Components
{
    public interface IComponent
    {
        ValueTask Update(GameContext game);

        GameObject Owner { get; }
    }
}
