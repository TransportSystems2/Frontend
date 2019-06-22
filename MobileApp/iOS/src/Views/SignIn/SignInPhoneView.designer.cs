// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignIn
{
    [Register("SignInPhoneView")]
    partial class SignInPhoneView
    {
        [Outlet]
        UIKit.UITextField CountryCodeField { get; set; }

        [Outlet]
        UIKit.UIButton GetCodeButton { get; set; }

        [Outlet]
        UIKit.UITextField PhoneNumberField { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CountryCodeField != null)
            {
                CountryCodeField.Dispose();
                CountryCodeField = null;
            }

            if (GetCodeButton != null)
            {
                GetCodeButton.Dispose();
                GetCodeButton = null;
            }

            if (PhoneNumberField != null)
            {
                PhoneNumberField.Dispose();
                PhoneNumberField = null;
            }
        }
    }
}