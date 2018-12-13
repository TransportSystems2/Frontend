// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TransportSystems.Frontend.MobileApp.iOS.Views.Orders
{
	[Register ("OrdersView")]
	partial class OrdersView
	{
		[Outlet]
		UIKit.UIButton AddOrderButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AddOrderButton != null) {
				AddOrderButton.Dispose ();
				AddOrderButton = null;
			}
		}
	}
}
