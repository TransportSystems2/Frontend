// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.Addresses
{
	[Register ("AddressesView")]
	partial class AddressesView
	{
		[Outlet]
		UIKit.UILabel FromLabel { get; set; }

		[Outlet]
		UIKit.UITextField FromTextField { get; set; }

		[Outlet]
		UIKit.UITextField InputTextField { get; set; }

		[Outlet]
		UIKit.UIButton NextButton { get; set; }

		[Outlet]
		UIKit.UILabel ToLabel { get; set; }

		[Outlet]
		UIKit.UITextField ToTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FromLabel != null) {
				FromLabel.Dispose ();
				FromLabel = null;
			}

			if (FromTextField != null) {
				FromTextField.Dispose ();
				FromTextField = null;
			}

			if (InputTextField != null) {
				InputTextField.Dispose ();
				InputTextField = null;
			}

			if (ToLabel != null) {
				ToLabel.Dispose ();
				ToLabel = null;
			}

			if (ToTextField != null) {
				ToTextField.Dispose ();
				ToTextField = null;
			}

			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}
		}
	}
}
