namespace BlazorGame.Core.Interfaces
{
    public interface IAssetLoaderFactory
    {
        IAssetLoader<TA> Get<TA>() where TA : IAsset;
    }
}