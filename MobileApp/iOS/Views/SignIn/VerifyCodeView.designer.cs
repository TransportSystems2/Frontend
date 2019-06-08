using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignIn
{
    [Register("VerifyCodeView")]
    partial class VerifyCodeView
    {
        [Outlet]
        UIKit.UITextField CodeTextField { get; set; }

        [Outlet]
        UIKit.UILabel PhoneNumberLabel { get; set; }

        [Outlet]
        UIKit.UIButton VerifyCodeButton { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (CodeTextField != null)
            {
                CodeTextField.Dispose();
                CodeTextField = null;
            }

            if (PhoneNumberLabel != null)
            {
                PhoneNumberLabel.Dispose();
                PhoneNumberLabel = null;
            }

            if (VerifyCodeButton != null)
            {
                VerifyCodeButton.Dispose();
                VerifyCodeButton = null;
            }
        }
    }
}