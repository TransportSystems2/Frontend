// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.Ios.Views.Booking
{
	[Register ("BookingView")]
	partial class BookingView
	{
		[Outlet]
		UIKit.UILabel CityLabel { get; set; }

		[Outlet]
		UIKit.UITextField CityTextField { get; set; }

		[Outlet]
		UIKit.UILabel ComissionLabel { get; set; }

		[Outlet]
		UIKit.UITextField ComissionTextField { get; set; }

		[Outlet]
		UIKit.UILabel DateLabel { get; set; }

		[Outlet]
		UIKit.UITextField DateTextField { get; set; }

		[Outlet]
		UIKit.UILabel DegreeOfDifficultyLabel { get; set; }

		[Outlet]
		UIKit.UITextField DegreeOfDifficultyTextField { get; set; }

		[Outlet]
		UIKit.UILabel FeedDistanceLabel { get; set; }

		[Outlet]
		UIKit.UILabel FeedDistanceValueLabel { get; set; }

		[Outlet]
		UIKit.UILabel FeedDurationValueLabel { get; set; }

		[Outlet]
		UIKit.UIButton NextButton { get; set; }

		[Outlet]
		UIKit.UILabel TotalDistanceLabel { get; set; }

		[Outlet]
		UIKit.UILabel TotalDistanceValueLabel { get; set; }

		[Outlet]
		UIKit.UILabel TotalPriceLabel { get; set; }

		[Outlet]
		UIKit.UILabel TotalPriceValueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}

			if (CityLabel != null) {
				CityLabel.Dispose ();
				CityLabel = null;
			}

			if (CityTextField != null) {
				CityTextField.Dispose ();
				CityTextField = null;
			}

			if (ComissionLabel != null) {
				ComissionLabel.Dispose ();
				ComissionLabel = null;
			}

			if (ComissionTextField != null) {
				ComissionTextField.Dispose ();
				ComissionTextField = null;
			}

			if (DateLabel != null) {
				DateLabel.Dispose ();
				DateLabel = null;
			}

			if (DateTextField != null) {
				DateTextField.Dispose ();
				DateTextField = null;
			}

			if (DegreeOfDifficultyLabel != null) {
				DegreeOfDifficultyLabel.Dispose ();
				DegreeOfDifficultyLabel = null;
			}

			if (DegreeOfDifficultyTextField != null) {
				DegreeOfDifficultyTextField.Dispose ();
				DegreeOfDifficultyTextField = null;
			}

			if (FeedDistanceLabel != null) {
				FeedDistanceLabel.Dispose ();
				FeedDistanceLabel = null;
			}

			if (FeedDistanceValueLabel != null) {
				FeedDistanceValueLabel.Dispose ();
				FeedDistanceValueLabel = null;
			}

			if (FeedDurationValueLabel != null) {
				FeedDurationValueLabel.Dispose ();
				FeedDurationValueLabel = null;
			}

			if (TotalDistanceLabel != null) {
				TotalDistanceLabel.Dispose ();
				TotalDistanceLabel = null;
			}

			if (TotalDistanceValueLabel != null) {
				TotalDistanceValueLabel.Dispose ();
				TotalDistanceValueLabel = null;
			}

			if (TotalPriceLabel != null) {
				TotalPriceLabel.Dispose ();
				TotalPriceLabel = null;
			}

			if (TotalPriceValueLabel != null) {
				TotalPriceValueLabel.Dispose ();
				TotalPriceValueLabel = null;
			}
		}
	}
}
