using BlazorGame.Core.Interfaces;
using BlazorGame.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Net.Http.Json;

namespace BlazorGame.Core.Assets.Loaders
{
    public class SpriteSheetAssetLoader : IAssetLoader<SpriteSheet>
    {
        private readonly HttpClient _httpClient;

        public SpriteSheetAssetLoader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<SpriteSheet> Load(string path)
        {
            var dto = await _httpClient.GetFromJsonAsync<SpriteSheetDTO>(path);

            var elementRef = new ElementReference(Guid.NewGuid().ToString());

            var sprites = dto.sprites
                .Select(s => new SpriteBase(s.name, elementRef, new Rectangle(s.x, s.y, s.width, s.height)))
                .ToArray();

            return new SpriteSheet(path, elementRef, dto.imagePath, sprites);
        }

        internal class SpriteSheetDTO
        {
            public string imagePath { get; set; }

            public SpriteDTO[] sprites { get; set; }

            internal class SpriteDTO
            {
                public string name { get; set; }
                public int x { get; set; }
                public int y { get; set; }
                public int width { get; set; }
                public int height { get; set; }
            }
        }
    }
}