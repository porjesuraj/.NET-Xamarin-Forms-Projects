using DeliveryApp.iOS.Models;
using Foundation;
using System;
using UIKit;

namespace DeliveryApp.iOS
{
    public partial class ViewController : UIViewController
    {

        bool hasLoggedIn = false;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            signinButton.TouchUpInside += Signin;
            // Perform any additional setup after loading the view, typically from a nib.

            //not working
            //var hideKeyboard = new UITapGestureRecognizer(() => View.EndEditing(true)); hideKeyboard.CancelsTouchesInView = false;

            emailText.ShouldReturn += (textField) => { textField.ResignFirstResponder(); return true; };

            passwordText.ShouldReturn += (textField) => { ((UITextField)textField).ResignFirstResponder(); return true; };


        }

        private async void Signin(object sender, EventArgs e)
        {
            var email = emailText.Text;
            var password = passwordText.Text;

            UIAlertController alert = null;

           bool result = await User.Login(email, password);

            if(result)
            {
                hasLoggedIn = true;
                alert = UIAlertController.Create("Success", "Welcome ", UIAlertControllerStyle.Alert); 

            }else
            {

                alert = UIAlertController.Create("Faliure", "Login Detail Incorrect ", UIAlertControllerStyle.Alert);

             }

            if(hasLoggedIn)
            PerformSegue("loginSegue", this);


            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "registerSegue")
            {
                var destinatonViewController = segue.DestinationViewController as RegisterViewController;

                destinatonViewController.emailAddress = emailText.Text;
            }
        }



        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {

            if(segueIdentifier == "loginSegue" )
            {
                return hasLoggedIn;

            }else
            {
                if (segueIdentifier == "registerSegue")
                    return true;
            }


            return false;


        }

    }
}
