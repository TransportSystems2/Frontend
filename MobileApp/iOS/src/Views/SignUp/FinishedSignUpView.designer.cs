// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.SignUp
{
	[Register ("FinishedSignUpView")]
	partial class FinishedSignUpView
	{
		[Outlet]
		UIKit.UILabel CongratulationsLabel { get; set; }

		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }

		[Outlet]
		UIKit.UIButton FinishButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CongratulationsLabel != null) {
				CongratulationsLabel.Dispose ();
				CongratulationsLabel = null;
			}

			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}

			if (FinishButton != null) {
				FinishButton.Dispose ();
				FinishButton = null;
			}
		}
	}
}
