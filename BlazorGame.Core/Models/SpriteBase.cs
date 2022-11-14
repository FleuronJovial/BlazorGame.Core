using BlazorGame.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGame.Core.Models
{
    public class SpriteBase : IAsset
    {
        public SpriteBase(string name, ElementReference elementRef, Rectangle bounds)
        {
            Name = name;
            ElementRef = elementRef;
            Bounds = bounds;
            Origin = new Point(bounds.Width / 2, bounds.Height / 2);
        }

        public string Name { get; }
        public ElementReference ElementRef { get; set; }
        public Rectangle Bounds { get; }
        public Point Origin { get; }
    }
}