using System.Threading.Tasks;

namespace BlazorGame.Core.Interfaces
{
    public interface IAssetLoader<TA> where TA : IAsset
    {
        ValueTask<TA> Load(string path);
    }
}