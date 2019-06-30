using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.Booking;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Booking
{
    [Activity(Label = "BookingView", WindowSoftInputMode = SoftInput.StateHidden)]
    public class BookingView : MvxActivity<BookingViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BookingView);
        }

    }
}