using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.Summary;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Summary
{
    [Activity(Label = "SummaryView", WindowSoftInputMode = SoftInput.StateHidden)]
    public class SummaryView : MvxActivity<SummaryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SummaryView);
        }

    }
}