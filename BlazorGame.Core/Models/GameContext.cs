using BlazorGame.Core.Interfaces;

namespace BlazorGame.Core.Models
{
    public abstract class GameContext
    {
        private bool _isInitialized = false;

        private Dictionary<Type, IGameService> _services = new();

        public T GetService<T>() where T : class, IGameService
        {
            _services.TryGetValue(typeof(T), out var service);
            return service as T;
        }

        protected void AddService(IGameService service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            _services[service.GetType()] = service;
        }

        public async ValueTask Step()
        {
            if (!_isInitialized)
            {
                await Init();

                GameTime.Start();

                _isInitialized = true;
            }

            GameTime.Step();

            foreach (var service in _services.Values)
                await service.Step();
        }

        protected abstract ValueTask Init();

        public GameTime GameTime { get; } = new();
        public Display Display { get; } = new();

    }
}