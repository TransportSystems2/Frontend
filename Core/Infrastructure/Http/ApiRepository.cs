using System;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.External.Interfaces;

namespace TransportSystems.Frontend.Core.Infrastructure.Http
{
    public class ApiRepository<T> where T : class
    {
        private readonly Lazy<T> _background;
        private readonly Lazy<T> _userInitiated;
        private readonly Lazy<T> _speculative;

        public ApiRepository(IAPIManager apiManager)
        {
            APIManager = apiManager;

            _background = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Background));

            _userInitiated = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.UserInitiated));

            _speculative = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Speculative));
        }

        public T Background => _background.Value;

        public T UserInitiated => _userInitiated.Value;

        public T Speculative => _speculative.Value;

        protected IAPIManager APIManager { get; }

        public T GetApi(RequestPriority priority)
        {
            switch (priority)
            {
                case RequestPriority.UserInitiated:
                    {
                        return UserInitiated;
                    }

                case RequestPriority.Background:
                    {
                        return Background;
                    }

                case RequestPriority.Speculative:
                    {
                        return Speculative;
                    }

                default:
                    {
                        return UserInitiated;
                    }
            }
        }
    }
}
