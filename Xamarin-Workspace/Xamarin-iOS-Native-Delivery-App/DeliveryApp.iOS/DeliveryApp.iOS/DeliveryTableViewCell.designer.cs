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
	[Register ("DeliveryTableViewCell")]
	partial class DeliveryTableViewCell
	{
		[Outlet]
	public	UIKit.UILabel CoordinateLabel { get; set; }

		[Outlet]
	public	UIKit.UILabel NameLabel { get; set; }

		[Outlet]
	public	UIKit.UILabel StatusLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (CoordinateLabel != null) {
				CoordinateLabel.Dispose ();
				CoordinateLabel = null;
			}
		}
	}
}
