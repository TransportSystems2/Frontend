// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp
{
    [Register ("UserTypeSelectorView")]
    partial class UserTypeSelectorView
    {
        [Outlet]
        UIKit.UIButton DispatcherButton { get; set; }


        [Outlet]
        UIKit.UILabel DispatcherCaptionLabel { get; set; }


        [Outlet]
        UIKit.UILabel DispatcherDescriptionLabel { get; set; }


        [Outlet]
        UIKit.UIButton DriverButton { get; set; }


        [Outlet]
        UIKit.UILabel DriverCaptionLabel { get; set; }


        [Outlet]
        UIKit.UILabel DriverDescriptionLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DispatcherButton != null) {
                DispatcherButton.Dispose ();
                DispatcherButton = null;
            }

            if (DispatcherCaptionLabel != null) {
                DispatcherCaptionLabel.Dispose ();
                DispatcherCaptionLabel = null;
            }

            if (DispatcherDescriptionLabel != null) {
                DispatcherDescriptionLabel.Dispose ();
                DispatcherDescriptionLabel = null;
            }

            if (DriverButton != null) {
                DriverButton.Dispose ();
                DriverButton = null;
            }

            if (DriverCaptionLabel != null) {
                DriverCaptionLabel.Dispose ();
                DriverCaptionLabel = null;
            }

            if (DriverDescriptionLabel != null) {
                DriverDescriptionLabel.Dispose ();
                DriverDescriptionLabel = null;
            }
        }
    }
}