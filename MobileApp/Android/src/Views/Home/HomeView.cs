using System;
using System.Windows.Input;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using TransportSystems.Frontend.App.ViewModels.Home;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Home
{
    [Activity(
       Theme = "@style/AppTheme",
       WindowSoftInputMode = SoftInput.AdjustResize | SoftInput.StateHidden)]
    public class HomeView : MvxAppCompatActivity<HomeViewModel>
    {
        public ICommand GoToOrdersCommand { get; set; }
        public ICommand GoToSettingsCommand { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.HomeView);

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(this).For(v => v.GoToSettingsCommand).To(vm => vm.ShowSettingsViewCommand);
            set.Bind(this).For(v => v.GoToOrdersCommand).To(vm => vm.ShowOrdersViewCommand);
            set.Apply();

            SubscribeToViewEvents();
        }

        protected override void OnDestroy()
        {
            UnsubscribeFromViewEvents();

            base.OnDestroy();
        }

        private void SubscribeToViewEvents()
        {
            var bottomNavigation = (BottomNavigationView)FindViewById(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected += HandleBottomNavigationItemSelected;
        }

        private void UnsubscribeFromViewEvents()
        {
            var bottomNavigation = (BottomNavigationView)FindViewById(Resource.Id.bottom_navigation);
            bottomNavigation.NavigationItemSelected -= HandleBottomNavigationItemSelected;
        }

        private void HandleBottomNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            try
            {
                if (e.Item.ItemId == Resource.Id.menu_settings)
                {
                    if (GoToSettingsCommand != null && GoToSettingsCommand.CanExecute(null))
                    {
                        GoToSettingsCommand.Execute(null);
                    }
                }

                if (e.Item.ItemId == Resource.Id.menu_orders)
                {
                    if (GoToOrdersCommand != null && GoToOrdersCommand.CanExecute(null))
                    {
                        GoToOrdersCommand.Execute(null);
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {exception.Message}");
            }
        }
    }
}