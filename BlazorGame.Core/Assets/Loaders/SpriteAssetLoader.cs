using BlazorGame.Core.Interfaces;
using BlazorGame.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGame.Core.Assets.Loaders
{
    public class SpriteAssetLoader : IAssetLoader<Sprite>
    {
        private readonly HttpClient _httpClient;

        public SpriteAssetLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<Sprite> Load(string path)
        {
            // TODO: remove call, add metadata in the assets file
            var bytes = await _httpClient.GetByteArrayAsync(path);
            await using var stream = new MemoryStream(bytes);
            using var image = await SixLabors.ImageSharp.Image.LoadAsync(stream);
            var bounds = new Rectangle(0, 0, image.Width, image.Height);

            var elementRef = new ElementReference(Guid.NewGuid().ToString());
            return new Sprite(path, elementRef, bounds, path);
        }
    }
}