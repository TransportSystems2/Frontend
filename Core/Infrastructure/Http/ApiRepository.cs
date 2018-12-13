using System;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.External.Interfaces;

namespace TransportSystems.Frontend.Core.Infrastructure.Http
{
    public class ApiRepository<T> where T: class
    {
        public ApiRepository(IAPIManager apiManager)
        {
            APIManager = apiManager;

            _background = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Background));

            _userInitiated = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.UserInitiated));

            _speculative = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Speculative));
        }

        protected IAPIManager APIManager { get; }

        private readonly Lazy<T> _background;
        private readonly Lazy<T> _userInitiated;
        private readonly Lazy<T> _speculative;

        public T Background => _background.Value;

        public T UserInitiated => _userInitiated.Value;

        public T Speculative => _speculative.Value;

        public T GetApi(RequestPriority priority)
        {
            switch(priority)
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
