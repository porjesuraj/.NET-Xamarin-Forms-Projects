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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITextField emailText { get; set; }

		[Outlet]
		UIKit.UITextField passwordText { get; set; }

		[Outlet]
		UIKit.UIButton registerButton { get; set; }

		[Outlet]
		UIKit.UIButton signinButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (emailText != null) {
				emailText.Dispose ();
				emailText = null;
			}

			if (passwordText != null) {
				passwordText.Dispose ();
				passwordText = null;
			}

			if (registerButton != null) {
				registerButton.Dispose ();
				registerButton = null;
			}

			if (signinButton != null) {
				signinButton.Dispose ();
				signinButton = null;
			}
		}
	}
}
