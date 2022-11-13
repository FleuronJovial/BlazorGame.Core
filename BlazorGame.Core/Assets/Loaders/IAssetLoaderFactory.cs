namespace BlazorGame.Core.Assets.Loaders
{
    public interface IAssetLoaderFactory
    {
        IAssetLoader<TA> Get<TA>() where TA : IAsset;
    }
}