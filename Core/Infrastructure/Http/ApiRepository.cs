using System;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.External.Interfaces;

namespace TransportSystems.Frontend.Core.Infrastructure.Http
{
    public class ApiRepository<T> where T : class
    {
        private readonly Lazy<T> background;
        private readonly Lazy<T> userInitiated;
        private readonly Lazy<T> speculative;

        public ApiRepository(IAPIManager apiManager)
        {
            APIManager = apiManager;

            background = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Background));

            userInitiated = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.UserInitiated));

            speculative = new Lazy<T>(() => APIManager.Get<T>((External.Models.Models.RequestPriority)RequestPriority.Speculative));
        }

        public T Background => background.Value;

        public T UserInitiated => userInitiated.Value;

        public T Speculative => speculative.Value;

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
