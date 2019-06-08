// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.Cargo
{
	[Register ("CargoView")]
	partial class CargoView
	{
		[Outlet]
		UIKit.UILabel BrandLabel { get; set; }

		[Outlet]
		UIKit.UITextField BrandTextField { get; set; }

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

		[Outlet]
		UIKit.UILabel WeightLabel { get; set; }

		[Outlet]
		UIKit.UITextField WeightTextField { get; set; }
		
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

			if (WeightLabel != null) {
				WeightLabel.Dispose ();
				WeightLabel = null;
			}

			if (WeightTextField != null) {
				WeightTextField.Dispose ();
				WeightTextField = null;
			}

			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}
		}
	}
}
