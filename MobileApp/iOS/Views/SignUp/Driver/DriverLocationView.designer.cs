// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.SignUp.Driver
{
	[Register ("DriverLocationView")]
	partial class DriverLocationView
	{
		[Outlet]
		UIKit.UILabel CityLabel { get; set; }

		[Outlet]
		UIKit.UITextField CityTextField { get; set; }

		[Outlet]
		UIKit.UILabel ProvinceLabel { get; set; }

		[Outlet]
		UIKit.UITextField ProvinceTextField { get; set; }

		[Outlet]
		UIKit.UILabel RegionLabel { get; set; }

		[Outlet]
		UIKit.UITextField RegionTextField { get; set; }

		[Outlet]
		UIKit.UIButton RegisterButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ProvinceLabel != null) {
				ProvinceLabel.Dispose ();
				ProvinceLabel = null;
			}

			if (ProvinceTextField != null) {
				ProvinceTextField.Dispose ();
				ProvinceTextField = null;
			}

			if (CityLabel != null) {
				CityLabel.Dispose ();
				CityLabel = null;
			}

			if (CityTextField != null) {
				CityTextField.Dispose ();
				CityTextField = null;
			}

			if (RegionLabel != null) {
				RegionLabel.Dispose ();
				RegionLabel = null;
			}

			if (RegionTextField != null) {
				RegionTextField.Dispose ();
				RegionTextField = null;
			}

			if (RegisterButton != null) {
				RegisterButton.Dispose ();
				RegisterButton = null;
			}
		}
	}
}
