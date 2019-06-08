// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignUp.Driver
{
    [Register ("VehicleView")]
    partial class VehicleView
    {
        [Outlet]
        UIKit.UILabel BrandLabel { get; set; }


        [Outlet]
        UIKit.UITextField BrandTextField { get; set; }


        [Outlet]
        UIKit.UILabel MaxTonCapacityLabel { get; set; }


        [Outlet]
        UIKit.UITextField MaxTonCapacityTextField { get; set; }


        [Outlet]
        UIKit.UIButton NextButton { get; set; }


        [Outlet]
        UIKit.UILabel RegistrationNumberLabel { get; set; }


        [Outlet]
        UIKit.UITextField RegistrationNumberTextField { get; set; }


        [Outlet]
        UIKit.UILabel TypeLabel { get; set; }


        [Outlet]
        UIKit.UITextField TypeTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BrandLabel != null) {
                BrandLabel.Dispose ();
                BrandLabel = null;
            }

            if (BrandTextField != null) {
                BrandTextField.Dispose ();
                BrandTextField = null;
            }

            if (MaxTonCapacityLabel != null) {
                MaxTonCapacityLabel.Dispose ();
                MaxTonCapacityLabel = null;
            }

            if (MaxTonCapacityTextField != null) {
                MaxTonCapacityTextField.Dispose ();
                MaxTonCapacityTextField = null;
            }

            if (NextButton != null) {
                NextButton.Dispose ();
                NextButton = null;
            }

            if (RegistrationNumberLabel != null) {
                RegistrationNumberLabel.Dispose ();
                RegistrationNumberLabel = null;
            }

            if (RegistrationNumberTextField != null) {
                RegistrationNumberTextField.Dispose ();
                RegistrationNumberTextField = null;
            }

            if (TypeLabel != null) {
                TypeLabel.Dispose ();
                TypeLabel = null;
            }

            if (TypeTextField != null) {
                TypeTextField.Dispose ();
                TypeTextField = null;
            }
        }
    }
}