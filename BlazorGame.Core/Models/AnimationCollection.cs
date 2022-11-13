using BlazorGame.Core.Interfaces;

namespace BlazorGame.Core.Models
{

    public class AnimationCollection : IAsset
    {
        private readonly IDictionary<string, Animation> _animations;

        public AnimationCollection(string name)
        {
            Name = name;

            _animations = new Dictionary<string, Animation>();
        }

        public string Name { get; }

        public Animation? GetAnimation(string name) => string.IsNullOrWhiteSpace(name) || !_animations.ContainsKey(name) ? null : _animations[name];

        internal void AddAnimation(Animation animation)
        {
            if (animation == null)
                throw new ArgumentNullException(nameof(animation));
            if (_animations.ContainsKey(animation.Name))
                throw new ArgumentException($"there is already an animation with the same name: {animation.Name}");

            _animations.Add(animation.Name, animation);
        }

    }
}