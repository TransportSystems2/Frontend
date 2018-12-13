﻿using Android.App;
using Android.OS;
using TransportSystems.Frontend.App.ViewModels.SignUp.Driver;
using MvvmCross.Platforms.Android.Views;

namespace TransportSystems.Frontend.MobileApp.Android.Views.SignUp.Driver
{
    [Activity(Label = "DriverView")]
    public class DriverView : MvxActivity<DriverViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DriverView);
        }
    }
}
