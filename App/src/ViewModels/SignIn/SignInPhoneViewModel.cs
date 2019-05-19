using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Plugin.FieldBinding;
using TransportSystems.Frontend.App.Models.SignIn;
using TransportSystems.Frontend.Core.Services.Interfaces.Signin;

namespace TransportSystems.Frontend.App.ViewModels.SignIn
{
    public class SignInPhoneViewModel : BaseViewModel
    {
        public SignInPhoneViewModel(ISignInService signUpService)
        {
            SignIpService = signUpService;

            GetCodeCommand = new MvxAsyncCommand(GetCodeAsync);
        }

        public readonly INC<string> CountryCode = new NC<string>();

        public readonly INC<string> PhoneNumber = new NC<string>();

        public IMvxCommand GetCodeCommand { get; private set; }

        protected ISignInService SignIpService { get; }

        public override void Prepare()
        {
            Title.Value = "Авторизация";

#if DEBUG
            CountryCode.Value = "7";
            PhoneNumber.Value = "9159771817";
#endif

            base.Prepare();
        }

        private async Task GetCodeAsync()
        {

            var phone = $"{CountryCode.Value}{PhoneNumber.Value}";

            var success = await SignIpService.GetCodeAsync(phone);
            if (success)
            {
                var canNavigate = await NavigationService.CanNavigate<VerifyCodeViewModel>();
                if (canNavigate)
                {
                    await NavigationService.Navigate<VerifyCodeViewModel, PhoneNumberM>(new PhoneNumberM { Phone = phone });
                }
            }

            Console.WriteLine($"status getting code: {success}");
        }
    }
}