﻿
using Android.App;
using Android.OS;
using Android.Telephony;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using TransportSystems.Frontend.App.ViewModels.Customer;

namespace TransportSystems.Frontend.MobileApp.Android.Views.Users
{
    [Activity(Label = "CustomerView")]
    public class CustomerView : MvxActivity<CustomerViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomerView);
            //var phone = (EditText)FindViewById(Resource.Id.phone);
            //phone.AddTextChangedListener(new PhoneNumberFormattingTextWatcher());
            //var aditionalPhone = (EditText)FindViewById(Resource.Id.aditional_phone);
            //aditionalPhone.AddTextChangedListener(new PhoneNumberFormattingTextWatcher());
        }

    }
}