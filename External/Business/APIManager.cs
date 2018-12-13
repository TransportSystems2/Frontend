using System;
using System.Net.Http;
using Fusillade;
using Refit;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Models.Models;

namespace TransportSystems.Frontend.External.Business
{
    public class APIManager : IAPIManager
    {
        public APIManager(string baseAddress, HttpMessageHandler baseHandler)
        {
            BaseAddress = baseAddress;
            BaseHandler = baseHandler;
        }

        protected string BaseAddress { get;  }

        protected HttpMessageHandler BaseHandler { get; }

        public T Get<T>(RequestPriority priority)
        {
            var messageHandler = new RateLimitedHttpMessageHandler(BaseHandler, (Priority)priority);
            var client = new HttpClient(messageHandler)
            {
                BaseAddress = new Uri(BaseAddress)
            };

            return RestService.For<T>(client);
        }
    }
}
