using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Services.Interfaces.Garages;
using TransportSystems.Frontend.Core.Services.Interfaces.SignUp;

namespace TransportSystems.Frontend.App.ViewModels.SignUp
{
    public class LocationViewModel<T> : BaseViewModel<T> where T : class
    {
        private const string Country = "Россия";

        public LocationViewModel(ISignUpService signUpService, IGarageService garageService)
        {
            SignUpService = signUpService;
            GarageService = garageService;

            RegisterCommand = new MvxAsyncCommand(Register);
        }

        public readonly INC<ICollection<string>> Provincies = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Cities = new NC<ICollection<string>>();

        public readonly INC<ICollection<string>> Regions = new NC<ICollection<string>>();

        public readonly INC<string> ProvinceLabel = new NC<string>();

        public readonly INC<string> Province = new NC<string>();

        public readonly INC<string> CityLabel = new NC<string>();

        public readonly INC<string> City = new NC<string>();

        public readonly INC<string> RegionLabel = new NC<string>();

        public readonly INC<string> Region = new NC<string>();

        public readonly INC<string> RegisterButtonText = new NC<string>();

        public IMvxCommand RegisterCommand { get; private set; }

        protected ISignUpService SignUpService { get; }

        protected IGarageService GarageService { get; }

        public override Task Initialize()
        {
            Province.Changed += HandleProvinceChanged;
            City.Changed += HandleCityChanged;

            return base.Initialize();
        }

        public override void Prepare()
        {
            Title.Value = "Местоположение";

            ProvinceLabel.Value = "Область";
            CityLabel.Value = "Город";
            RegionLabel.Value = "Регион";
            RegisterButtonText.Value = "Зарегистрироваться";

            base.Prepare();
        }

        public async override void Start()
        {
            base.Start();

            await GetAvailableProvinces();
        }

        protected virtual Task Register()
        {
            return Task.CompletedTask;
        }

        private async Task GetAvailableProvinces()
        {
            ICollection<string> provinces = null;
            try
            {
                provinces = await GarageService.GetAvailableProvinces(Country, RequestPriority.UserInitiated);
            }
            catch (Exception e)
            {

            }

            if (provinces == null || provinces.Count == 0)
            {
                return;
            }

            Provincies.Value = provinces;
            Province.Value = provinces.FirstOrDefault();
        }

        private async Task GetAvailableCities()
        {
            if (string.IsNullOrEmpty(Province.Value))
            {
                return;
            }

            ICollection<string> cities = null;
            try
            {
                cities = await GarageService.GetAvailableLocalities(Country, Province.Value, RequestPriority.UserInitiated);
            }
            catch (Exception e)
            {

            }

            if (cities == null || cities.Count == 0)
            {
                return;
            }

            Cities.Value = cities;
            City.Value = cities.FirstOrDefault();
        }

        private async Task GetAvailableRegions()
        {
            if (string.IsNullOrEmpty(Province.Value) || string.IsNullOrEmpty(City.Value))
            {
                return;
            }

            ICollection<string> regions = null;
            try
            {
                regions = await GarageService.GetAvailableDistricts(Country, Province.Value, City.Value, RequestPriority.UserInitiated);
            }
            catch (Exception e)
            {

            }

            if (regions == null || regions.Count == 0)
            {
                return;
            }

            Regions.Value = regions;
            Region.Value = regions.FirstOrDefault();
        }

        private async void HandleProvinceChanged(object sender, EventArgs e)
        {
            await GetAvailableCities();
        }

        private async void HandleCityChanged(object sender, EventArgs e)
        {
            await GetAvailableRegions();
        }
    }
}