// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DeliveryApp.iOS
{
	[Register ("NewDeliveryViewController")]
	partial class NewDeliveryViewController
	{
		[Outlet]
		MapKit.MKMapView DestinationMapView { get; set; }

		[Outlet]
		MapKit.MKMapView OriginMapVIew { get; set; }

		[Outlet]
		UIKit.UITextField packageNameTextField { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem saveBarButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (OriginMapVIew != null) {
				OriginMapVIew.Dispose ();
				OriginMapVIew = null;
			}

			if (DestinationMapView != null) {
				DestinationMapView.Dispose ();
				DestinationMapView = null;
			}

			if (packageNameTextField != null) {
				packageNameTextField.Dispose ();
				packageNameTextField = null;
			}

			if (saveBarButton != null) {
				saveBarButton.Dispose ();
				saveBarButton = null;
			}
		}
	}
}
