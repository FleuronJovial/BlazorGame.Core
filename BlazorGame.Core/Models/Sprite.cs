using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGame.Core.Models
{
    public class Sprite : SpriteBase
    {
        public Sprite(string name, ElementReference elementRef, Rectangle bounds, string imagePath) : base(name, elementRef, bounds)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentNullException(nameof(imagePath));
            ImagePath = imagePath;
        }

        public string ImagePath { get; }

    }
}