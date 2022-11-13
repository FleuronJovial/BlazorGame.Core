using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace BlazorGame.Core.Models
{
    public class Animation
    {
        public Animation(string name, int fps, Size frameSize, int framesCount,
            ElementReference imageRef, string imageData, Size imageSize,
            AnimationCollection animations)
        {
            Name = name;
            Fps = fps;
            FrameSize = frameSize;
            FramesCount = framesCount;
            ImageRef = imageRef;
            ImageData = imageData;
            ImageSize = imageSize;

            animations.AddAnimation(this);
        }
        public string Name { get; }
        public int Fps { get; }
        public int FramesCount { get; }
        public Size FrameSize { get; }
        public Size ImageSize { get; }
        public ElementReference ImageRef { get; set; }
        public string ImageData { get; }
    }
}
