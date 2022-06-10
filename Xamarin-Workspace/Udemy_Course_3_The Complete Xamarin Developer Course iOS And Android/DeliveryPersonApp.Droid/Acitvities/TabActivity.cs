using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using DeliveryPersonApp.Droid.fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryPersonApp.Droid.Acitvities
{
    [Activity(Label = "TabActivity")]
    public class TabActivity : Android.Support.V4.App.FragmentActivity
    {
        TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Tabs);

            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTab);

            tabLayout.TabSelected += TabLayout_TabSelected;

            FragmentNavigate(new DeliveringFragment());
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveringFragment() );
                    break;

                case 1:
                    FragmentNavigate(new WaitingFragment() );
                    break;


                case 2:
                    FragmentNavigate(new  DeliveredFragment());

                    break;

                default:
                    break;
            }
        }

        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();

            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}