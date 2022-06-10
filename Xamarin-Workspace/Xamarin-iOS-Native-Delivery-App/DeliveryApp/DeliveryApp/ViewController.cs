using Foundation;
using System;
using UIKit;

namespace DeliveryApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //loginButton.PrimaryActionTriggered += loginButtonClicked;

        }


       public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);


            if(segue.Identifier == "registerSegue")

            {
                var destinationViewController = segue.DestinationViewController as RegisterViewController;

                //if(emailTextField.Text != "")
               // destinationViewController.emailAddress = emailTextField.Text;
              

                   // destinationViewController.emailAddress = "Suraj";
              
            }
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        
    }
}
