using System.Threading.Tasks;

namespace BlazorGame.Core.Interfaces
{
    public interface IAssetsResolver
    {
        ValueTask<TA> Load<TA>(string path) where TA : IAsset;
        TA Get<TA>(string path) where TA : class, IAsset;
    }
}