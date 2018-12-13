// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp.Dispatcher
{
    [Register ("DispatcherView")]
    partial class DispatcherView
    {
        [Outlet]
        UIKit.UILabel FirstNameLabel { get; set; }


        [Outlet]
        UIKit.UITextField FirstNameTextField { get; set; }


        [Outlet]
        UIKit.UILabel LastNameLabel { get; set; }


        [Outlet]
        UIKit.UITextField LastNameTextField { get; set; }


        [Outlet]
        UIKit.UIButton NextButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FirstNameLabel != null) {
                FirstNameLabel.Dispose ();
                FirstNameLabel = null;
            }

            if (FirstNameTextField != null) {
                FirstNameTextField.Dispose ();
                FirstNameTextField = null;
            }

            if (LastNameLabel != null) {
                LastNameLabel.Dispose ();
                LastNameLabel = null;
            }

            if (LastNameTextField != null) {
                LastNameTextField.Dispose ();
                LastNameTextField = null;
            }

            if (NextButton != null) {
                NextButton.Dispose ();
                NextButton = null;
            }
        }
    }
}